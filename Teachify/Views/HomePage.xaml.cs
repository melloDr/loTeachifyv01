using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Models;
using Teachify.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Instructor> Instructors;
        private bool First = true;
        public HomePage()
        {
            InitializeComponent();
            Instructors = new ObservableCollection<Instructor>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiService apiService = new ApiService();
                var instructors = await apiService.GetIntructors();
                foreach (var instructor in instructors)
                {
                    Instructors.Add(instructor);
                }
                lvInstructors.ItemsSource = Instructors;
            }
            First = false;
        }

        private void lvInstructors_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedInstructor = e.SelectedItem as Instructor;
            Navigation.PushAsync(new InstructorProfilePage(selectedInstructor.Id));
        }

        private void tbSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindInstructorPage());
        }
    }
}