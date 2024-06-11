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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            var response = await apiService.GetToken(EntEmail.Text, EntPassword.Text);
            if (response.Data.access_token == null || string.IsNullOrEmpty(response.Data.access_token))
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {
                Preferences.Set("useremail", EntEmail.Text);
                Preferences.Set("password", EntPassword.Text);
                Preferences.Set("accesstoken", response.Data.access_token);
                Application.Current.MainPage = new MasterPage();
            }
        }

        private void TapSignUp_Tapped(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));
            Navigation.PushAsync(new SignUpPage());
        }

        private void TapForgotPassword_Tapped(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new NavigationPage(new ForgotPasswordPage()));
            Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}