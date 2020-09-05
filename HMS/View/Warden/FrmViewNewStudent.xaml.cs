using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Warden;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmViewNewStudent : ContentPage
    {
        NewAdmittedStudent vm;
        ObservableCollection<Students> Students;
        ObservableCollection<Students> students;
        public FrmViewNewStudent()
        {
            InitializeComponent();
            BindingContext = vm = new NewAdmittedStudent();
            //listview.ItemsSource = vm.GetStudents;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //listview.ItemsSource = vm.GetStudents;
        }
        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    Students = new ObservableCollection<Students>();
                    if (vm.GetStudents != null)
                    {
                        foreach (var items in vm.GetStudents)
                        {
                            if (!string.IsNullOrEmpty(items.roomId) || items.roomId != null)
                            {
                                if (txtsearchbykeyword.Text != string.Empty)
                                {
                                    if (items.roomId.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.roomId.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        Students.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = Students;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtsearchbykeyword.Text = ((Students)e.SelectedItem).roomId;
                students = new ObservableCollection<Students>();
                if (Students != null)
                {
                    foreach (var items in Students)
                    {
                        if (items.roomId == txtsearchbykeyword.Text)
                            students.Add(items);
                    }
                }
                listview.ItemsSource = students;
            }
            catch (Exception ex)
            {

            }
        }
    }
}