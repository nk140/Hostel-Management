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
    public partial class FrmStudentParentContact : ContentPage
    {
        StudentParentInfo vm;
        public ObservableCollection<Parents> parents;
        public ObservableCollection<Parents> GetParents;
        public FrmStudentParentContact()
        {
            InitializeComponent();
            BindingContext = vm = new StudentParentInfo();
        }
        private void txtsearchbykeyword_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    parents = new ObservableCollection<Parents>();
                    if (vm.Parentlist != null)
                    {
                        foreach (var data in vm.Parentlist)
                        {
                            if (!string.IsNullOrEmpty(data.Name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (data.Name.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || data.Name.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        parents.Add(data);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = parents;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtsearchbykeyword.Text = ((Parents)e.SelectedItem).Name;
                if (parents != null)
                {
                    GetParents = new ObservableCollection<Parents>();
                    foreach (var items in parents)
                    {
                        if (items.Name == txtsearchbykeyword.Text)
                            GetParents.Add(items);
                    }
                }
                lv_contact.ItemsSource = GetParents;
            }
            catch (Exception ex)
            {

            }
        }
    }
}