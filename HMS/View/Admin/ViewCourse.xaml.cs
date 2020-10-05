using HMS.Models;
using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCourse : ContentPage
    {
        ViewCourseVM vm;
        ObservableCollection<CourseDetailModel> courseDetailModels;
        ObservableCollection<CourseDetailModel> courseDetailModels1;
        public ViewCourse()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewCourseVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void txtsearchbycoursename_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    courseDetailModels = new ObservableCollection<CourseDetailModel>();
                    if (vm.CourseDetailModels1 != null)
                    {
                        foreach (var items in vm.CourseDetailModels1)
                        {
                            if (!string.IsNullOrEmpty(items.courseName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbycoursename.Text))
                                {
                                    if (items.courseName.ToUpper().StartsWith(txtsearchbycoursename.Text.ToUpper()) || items.courseName.ToLower().StartsWith(txtsearchbycoursename.Text.ToLower()))
                                        courseDetailModels.Add(items);
                                }
                            }
                        }
                        txtsearchbycoursename.ItemsSource = courseDetailModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbycoursename_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbycoursename.Text = ((CourseDetailModel)e.SelectedItem).courseName;
            courseDetailModels1 = new ObservableCollection<CourseDetailModel>();
            if (courseDetailModels != null)
            {
                foreach (var items in courseDetailModels)
                {
                    if (txtsearchbycoursename.Text == items.courseName)
                    {
                        courseDetailModels1.Add(items);
                        break;
                    }
                }
                roombeddata.ItemsSource = courseDetailModels1;
            }
        }
    }
}