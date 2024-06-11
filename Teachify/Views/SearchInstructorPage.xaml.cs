using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchInstructorPage : ContentPage
    {
        public SearchInstructorPage(string course,string city,string gender)
        {
            InitializeComponent();
        }
    }
}