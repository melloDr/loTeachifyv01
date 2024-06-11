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
    public partial class FindInstructorPage : ContentPage
    {
        public ObservableCollection<Course> Courses;
        public ObservableCollection<City> Cities;
        ApiService ApiService = new ApiService();
        public FindInstructorPage()
        {
            InitializeComponent();
            Courses = new ObservableCollection<Course>();
            Cities = new ObservableCollection<City>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCoursesAndCity();
        }
        public async void LoadCoursesAndCity()
        {
            var courses = await ApiService.GetCourses();
            foreach (var item in courses)
                Courses.Add(item);

            PickerCourse.ItemsSource = Courses;

            var cities = await ApiService.GetCities();
            foreach (var item in cities)
                Cities.Add(item);

            PickerCity.ItemsSource = Cities;
        }

        private async void btnSearchInstructor_Clicked(object sender, EventArgs e)
        {
            if (PickerCourse.SelectedIndex < 0 || PickerCity.SelectedIndex < 0 || PickerGender.SelectedIndex < 0)
                await DisplayAlert("Oops", "Please select all the options", "Cancel");
            else
            {
                var course = PickerCourse.Items[PickerCourse.SelectedIndex].Trim();
                var city= PickerCity.Items[PickerCity.SelectedIndex].Trim();
                var gender = PickerGender.Items[PickerGender.SelectedIndex].Trim();
                Navigation.PushAsync(new SearchInstructorPage(course, city, gender));
            }

        }
    }
}