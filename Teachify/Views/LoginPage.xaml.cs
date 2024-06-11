using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            var response = await apiService.GetToken(EntEmail.Text, EntPassword.Text);
            if (response.Data.access_token == null || string.IsNullOrEmpty(response.Data.access_token))
            {
                DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {
                Application.Current.MainPage = new MasterPage();
            }
        }
    }
}