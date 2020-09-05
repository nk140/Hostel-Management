﻿using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace HMS.ViewModel
{
    public class NewsFeedViewModel : BaseViewModel, Inewsfeeddata
    {
        WardenService warden;
        private ObservableCollection<NewsFeed> newsFeeds = new ObservableCollection<NewsFeed>();
        private bool _IsResponsenotok;
        #region listproperties
        public ObservableCollection<NewsFeed> NewsFeeds
        {
            get
            {
                return newsFeeds;
            }
            set
            {
                newsFeeds = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region nonetworkconnection
        public bool IsResponsenotok
        {
            get
            {
                return _IsResponsenotok;
            }
            set
            {
                _IsResponsenotok = value;
                OnPropertyChanged();
            }
        }
        #endregion
        ////public string newstitle1;
        ////public string newstitle2;
        ////public string newstitle3;
        ////public string linkurl1;
        ////public string linkurl2;
        ////public string linkurl3;
        ////#region properties
        ////public string NewsTitle1
        ////{
        ////    get
        ////    {
        ////        return newstitle1;
        ////    }
        ////    set
        ////    {
        ////        newstitle1 = value;
        ////        OnPropertyChanged();
        ////    }
        ////}
        ////public string NewsTitle2
        ////{
        ////    get
        ////    {
        ////        return newstitle2;
        ////    }
        ////    set
        ////    {
        ////        newstitle2 = value;
        ////        OnPropertyChanged();
        ////    }
        ////}
        ////public string NewsTitle3
        ////{
        ////    get
        ////    {
        ////        return newstitle3;
        ////    }
        ////    set
        ////    {
        ////        newstitle3 = value;
        ////        OnPropertyChanged();
        ////    }
        ////}
        ////public string Linkurl1
        ////{
        ////    get
        ////    {
        ////        return linkurl1;
        ////    }
        ////    set
        ////    {
        ////        linkurl1 = value;
        ////        OnPropertyChanged();
        ////    }
        ////}
        ////public string Linkurl2
        ////{
        ////    get
        ////    {
        ////        return linkurl2;
        ////    }
        ////    set
        ////    {
        ////        linkurl2 = value;
        ////        OnPropertyChanged();
        ////    }
        ////}
        ////public string Linkurl3
        ////{
        ////    get
        ////    {
        ////        return linkurl3;
        ////    }
        ////    set
        ////    {
        ////        linkurl3 = value;
        ////        OnPropertyChanged();
        ////    }
        ////}
        //#endregion
        public NewsFeedViewModel()
        {
            var profiles = Connectivity.ConnectionProfiles;
            if (profiles.Contains(ConnectionProfile.WiFi) || profiles.Contains(ConnectionProfile.Cellular))
            {
                warden = new WardenService(this);
                warden.GetNewsFeedDatalist();
            }
            else
            {
                IsResponsenotok = true;
            }
        }
        public async void Getnewsfeedlist(ObservableCollection<NewsFeed> newsFeeds)
        {
            NewsFeeds = new ObservableCollection<NewsFeed>();
            NewsFeeds = newsFeeds;
            //NewsTitle1 = newsFeeds[0].newsTitle;
            //NewsTitle2 = newsFeeds[1].newsTitle;
            //NewsTitle3 = newsFeeds[2].newsTitle;
            //Linkurl1 = newsFeeds[0].linkUrl;
            //Linkurl2 = newsFeeds[1].linkUrl;
            //Linkurl3 = newsFeeds[2].linkUrl;
            OnPropertyChanged();
        }

        public void Servicefailed()
        {
            IsResponsenotok = true;
        }
    }
}
