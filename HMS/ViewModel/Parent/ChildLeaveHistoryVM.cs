using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.ViewModel.Parent
{
    public class ChildLeaveHistoryVM : BaseViewModel, iviewchildleave
    {
        ParentService parentService;
        private ObservableCollection<childleavehistory> childleavehistories = new ObservableCollection<childleavehistory>();
        public ObservableCollection<childleavehistory> Childleavehistories
        {
            get
            {
                return childleavehistories;
            }
            set
            {
                childleavehistories = value;
                OnPropertyChanged("Childleavehistories");
            }
        }
        public ChildLeaveHistoryVM()
        {

        }
        public void Loadchildleavelist(ObservableCollection<childleavehistory> childleavehistories)
        {

        }

        public async void servicefailed(string result)
        {

        }
    }
}
