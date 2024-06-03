using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void TapHome_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ChangePasswordPage());
            IsPresented = false;
        }

        private void TapBecomeInstructor_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new BecomeInstructorPage());
            IsPresented = false;
        }

        private void TapFaq_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FaqPage());
            IsPresented = false;
        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new LogoutPage());
            IsPresented = false;
        }
    }
}