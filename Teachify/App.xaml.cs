using System;
using Teachify.Services;
using Teachify.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MasterPage();
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
