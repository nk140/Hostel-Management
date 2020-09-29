﻿using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Admin;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class ViewHostelByArea : PopupPage
    {
        ViewFilteredHostelVM vm;
        string areaids;
        public ObservableCollection<AreaModel> areaModels;
        public ViewHostelByArea()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredHostelVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.areaid = string.Empty;
        }
        private async void btnviewhostelbyarea_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(App.areaid))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Please Enter Area Name", "OK");
            }
            else if(string.IsNullOrEmpty(areaids))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Please Enter Area Name", "OK");
            }
            else
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ViewHostel(areaids));
                await App.Current.MainPage.Navigation.PopPopupAsync(true);
            }
        }
        private void ddarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //App.areaid = ddarea.Items[ddarea.SelectedIndex];
        }

        private void txtselectbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    areaModels = new ObservableCollection<AreaModel>();
                    if (vm.AreaLists != null)
                    {
                        foreach (var items in vm.AreaLists)
                        {
                            if (!string.IsNullOrEmpty(items.areaName) || items.areaName != null)
                            {
                                if (txtselectbyarea.Text != string.Empty)
                                {

                                    if (items.areaName.ToUpper().StartsWith(txtselectbyarea.Text.ToUpper()) || items.areaName.ToLower().StartsWith(txtselectbyarea.Text.ToLower()))
                                        areaModels.Add(items);
                                }
                            }
                        }
                        txtselectbyarea.ItemsSource = areaModels;
                    }
                    else
                    {
                         DisplayAlert("HMS", "No Matching Area Name", "OK");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtselectbyarea_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtselectbyarea.Text = ((AreaModel)e.SelectedItem).areaName;
                string value = ((AreaModel)e.SelectedItem).id;
                App.areaid = value;
                areaids = App.areaid;
               // vm.selectedarea(App.areaid);
            }
            catch (Exception ex)
            {

            }
        }
    }
}