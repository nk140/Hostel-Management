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
    public partial class ViewLeaveType : ContentPage
    {
        ViewLeaveTypeVM vm;
        ObservableCollection<LeaveTypeModel> leaveTypeModels;
        ObservableCollection<LeaveTypeModel> leaveTypeModels1;
        public ViewLeaveType()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewLeaveTypeVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyleavetype_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    leaveTypeModels = new ObservableCollection<LeaveTypeModel>();
                    if (vm.LeaveTypeList != null)
                    {
                        foreach (var items in vm.LeaveTypeList)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyleavetype.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyleavetype.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyleavetype.Text.ToLower()))
                                        leaveTypeModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyleavetype.ItemsSource = leaveTypeModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyleavetype_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyleavetype.Text = ((LeaveTypeModel)e.SelectedItem).name;
            leaveTypeModels1 = new ObservableCollection<LeaveTypeModel>();
            if (leaveTypeModels != null)
            {
                foreach (var items in leaveTypeModels)
                {
                    if (txtsearchbyleavetype.Text == items.name)
                        leaveTypeModels1.Add(items);
                }
                leavetypelist.ItemsSource = leaveTypeModels1;
            }
        }
    }
}