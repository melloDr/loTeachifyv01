﻿using System;
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
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void btnChangePassword_Clicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            var response = await apiService.ChangePassword(entOldPassword.Text, entNewPassword.Text, entConfirmPassword.Text);
            if (!response)
            {
                await DisplayAlert("Oops", "Something wrong", "Cancel");
            }
            else
            {
                await DisplayAlert("Password changed", "Kindly login with the new password", "Alright");
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}