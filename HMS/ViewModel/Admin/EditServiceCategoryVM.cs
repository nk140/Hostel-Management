using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class EditServiceCategoryVM : BaseViewModel,IEditservicecategory
    {
        MasterServices web;
        private UpdateServiceCategoryModel updateServiceCategoryModel = new UpdateServiceCategoryModel();
        public UpdateServiceCategoryModel UpdateServiceCategoryModel
        {
            get
            {
                return updateServiceCategoryModel;
            }
            set
            {
                updateServiceCategoryModel = value;
                OnPropertyChanged("UpdateServiceCategoryModel");
            }
        }
        public ICommand UpdateServiceCategoryCommand => new Command(OnUpdateServiceCategoryCommand);
        public EditServiceCategoryVM(string id,string name,string userid)
        {
            UpdateServiceCategoryModel.id = id;
            UpdateServiceCategoryModel.name = name;
            UpdateServiceCategoryModel.userId = userid;
            web = new MasterServices((IEditservicecategory)this);
        }
        public async void OnUpdateServiceCategoryCommand()
        {
            if(validate())
            {
                web.UpdateServiceCategory(UpdateServiceCategoryModel);
            }
        }
        bool validate()
        {
            if(UpdateServiceCategoryModel.name.Length==0 || string.IsNullOrEmpty(UpdateServiceCategoryModel.name))
            {
                App.Current.MainPage.DisplayAlert("HMS","Name required", "OK");
                return false;
            }
            return true;
        }
        public async void getallservicecategory(string result)
        {
            UpdateServiceCategoryModel = new UpdateServiceCategoryModel();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateServiceCategoryModel");
        }

        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
