using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace HMS.ViewModel.Parent
{
    public class ParentProfileVM : BaseViewModel, Iviewchildhosteldetail
    {
        ParentService parent;
        private ObservableCollection<ChildHostelDetailModel> childHostelDetailModels = new ObservableCollection<ChildHostelDetailModel>();
        public ObservableCollection<ChildHostelDetailModel> ChildHostelDetailModels
        {
            get
            {
                return childHostelDetailModels;
            }
            set
            {
                childHostelDetailModels = value;
                OnPropertyChanged("ChildHostelDetailModels");
            }
        }
        public ParentProfileVM()
        {
            parent = new ParentService(this);
            string studentid = SecureStorage.GetAsync("studentId").GetAwaiter().GetResult();
            parent.GetChildHostelData(studentid);
        }
        public void LoadChildHostelDetails(ObservableCollection<ChildHostelDetailModel> childHostelDetailModels)
        {
            ChildHostelDetailModels = childHostelDetailModels;
            OnPropertyChanged("ChildHostelDetailModels");
        }

        public void servicefailed(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
