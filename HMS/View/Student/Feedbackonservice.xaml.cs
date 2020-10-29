using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Feedbackonservice : ContentPage
    {
        FeedBackSubmissionVM vm;
        ObservableCollection<WardenServiceModel> WardenServiceData;
        public Feedbackonservice()
        {
            InitializeComponent();
            BindingContext = vm = new FeedBackSubmissionVM();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        WardenServiceData = new ObservableCollection<WardenServiceModel>();
            //        if (vm.WardenServiceData != null)
            //        {
            //            foreach (var items in vm.WardenServiceData)
            //            {
            //                if (!string.IsNullOrEmpty(items.name))
            //                {
            //                    if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
            //                    {
            //                        if (items.name.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
            //                            WardenServiceData.Add(items);
            //                    }
            //                }
            //            }
            //            txtsearchbykeyword.ItemsSource = WardenServiceData;
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            //txtsearchbykeyword.Text = ((WardenServiceModel)e.SelectedItem).name;
            //vm.FeedbackDetailsByStudent.serviceid= ((WardenServiceModel)e.SelectedItem).id.ToString();
        }

        private void ddservicerating_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vm.FeedbackDetailsByStudent.servicerating = ddservicerating.Items[ddservicerating.SelectedIndex];
        }

        private void ratingView2_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            double result = ratingView2.Value;
            vm.FeedbackDetailsByStudent.personRating = result.ToString();
        }
    }
}