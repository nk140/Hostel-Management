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
    public class EditNewsFeedVM : BaseViewModel, IEditnewsfeeddata
    {
        private UpdateNewsFeed updateNewsFeed = new UpdateNewsFeed();
        MasterServices web;
        public UpdateNewsFeed UpdateNewsFeeds
        {
            get
            {
                return updateNewsFeed;
            }
            set
            {
                updateNewsFeed = value;
                OnPropertyChanged("UpdateNewsFeeds");
            }
        }
        public ICommand UpdateNewsFeedCommand => new Command(OnUpdateNewsFeedCommand);
        public EditNewsFeedVM(string id, string title, string description, string startdates, string lastdates, string linkId)
        {
            UpdateNewsFeeds.id = id;
            UpdateNewsFeeds.newsTitle = title;
            UpdateNewsFeeds.newsDescription = description;
            UpdateNewsFeeds.startDate = startdates;
            UpdateNewsFeeds.lastDate = lastdates;
            UpdateNewsFeeds.linkId = linkId;
            web = new MasterServices((IEditnewsfeeddata)this);
        }
        public async void OnUpdateNewsFeedCommand()
        {
            if(validate())
            {
                UpdateNewsFeeds.displayfor = "Admin";
                web.Updatenewsfeed(UpdateNewsFeeds);
            }
        }
        bool validate()
        {
            if(UpdateNewsFeeds.newsDescription.Length==0 ||string.IsNullOrEmpty(UpdateNewsFeeds.newsDescription))
            {
                App.Current.MainPage.DisplayAlert("HMS", "News Description Required", "OK");
                return false;
            }
            else if(UpdateNewsFeeds.startDate.Length==0 || string.IsNullOrEmpty(UpdateNewsFeeds.startDate))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Start Date Required", "OK");
                return false;
            }
            else if(UpdateNewsFeeds.lastDate.Length==0 || string.IsNullOrEmpty(UpdateNewsFeeds.lastDate))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Last Date Required", "OK");
                return false;
            }
            else if(UpdateNewsFeeds.startTime.Length==0 || string.IsNullOrEmpty(UpdateNewsFeeds.startTime))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Start Time Required", "OK");
                return false;
            }
            else if (UpdateNewsFeeds.lastTime.Length == 0 || string.IsNullOrEmpty(UpdateNewsFeeds.lastTime))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Last Time Required", "OK");
                return false;
            }
            return true;
        }
        public async void Servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void UpdateNewsFeed(string result)
        {
            UpdateNewsFeeds = new UpdateNewsFeed();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateNewsFeeds");
        }
    }
}
