using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDisciplinaryAction : ContentPage
    {
        ViewStudentDisciplinaryActionVM vm;
        ObservableCollection<StudentProfileModel> StudentProfileModels1;
        public ViewDisciplinaryAction()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewStudentDisciplinaryActionVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void txtsearchbywarden_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    StudentProfileModels1 = new ObservableCollection<StudentProfileModel>();
                    if (vm.StudentProfileModels != null)
                    {
                        foreach (var items in vm.StudentProfileModels)
                        {
                            if (!string.IsNullOrEmpty(items.wardenName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbywarden.Text))
                                {
                                    if (items.wardenName.ToUpper().StartsWith(txtsearchbywarden.Text.ToUpper()) || items.wardenName.ToLower().StartsWith(txtsearchbywarden.Text.ToLower()))
                                        StudentProfileModels1.Add(items);
                                }
                            }
                        }
                        txtsearchbywarden.ItemsSource = StudentProfileModels1;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbywarden_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbywarden.Text = ((StudentProfileModel)e.SelectedItem).wardenName;
            //var id = ((StudentProfileModel)e.SelectedItem).wardenId;
           // vm.GetDisciplinarylist(id);
        }
    }
}