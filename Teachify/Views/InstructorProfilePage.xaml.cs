using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructorProfilePage : ContentPage
    {
        private string number;
        private string email;
        public InstructorProfilePage(Guid id)
        {
            InitializeComponent();
            GetInstructorProfile(id);

        }

        public async void GetInstructorProfile(Guid id)
        {
            ApiService apiService = new ApiService();
            var instructor = await apiService.GetIntructor(id);
            ImgProfile.Source = instructor.ImageArray;
            lblCity.Text = instructor.City;
            lblLanguage.Text = instructor.Language; 
            lblNationality.Text = instructor.Nationality;
            lblExperience.Text = instructor.Experience;
            lblSpecialization.Text = instructor.CourseDomain;
            lblName.Text = instructor.Name;
            lblOneLineDescription.Text = instructor.OneLineTitle;
            lblHourlyRate.Text = instructor.HourlyRate;
            lblDescription.Text = instructor.Description;
            number = instructor.Phone;
            email = instructor.Email;
        }

        private void btnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(number);
        }

        private void btnSms_Clicked(object sender, EventArgs e)
        {
            var message = new SmsMessage("", number);
            Sms.ComposeAsync(message);
        }

        private void btnEmail_Clicked(object sender, EventArgs e)
        {
            var message = new EmailMessage("", "", email);
            Email.ComposeAsync(message);
        }
    }
}