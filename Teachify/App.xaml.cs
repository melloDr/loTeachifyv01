using System;
using Teachify.Services;
using Teachify.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Preferences.Get("accesstoken","")))
            {
                MainPage = new MasterPage();
            }
            else if (string.IsNullOrEmpty(Preferences.Get("useremail", "")) && string.IsNullOrEmpty(Preferences.Get("password", "")))
            {
                MainPage = new NavigationPage(new LoginPage());
                //MainPage = new LoginPage();
            }
            //DependencyService.Register<MockDataStore>();
            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
