using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace HMS.Services
{
    public class ParentService
    {
        IWardenDetail wardenDetail;
        public ParentService(IWardenDetail wardenDetaildata)
        {
            wardenDetail = wardenDetaildata;
        }
        public async void GetAllWardenData()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetAllWarden);
                string result = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<WardenInfoModel> data_ = JsonConvert.DeserializeObject<ObservableCollection<WardenInfoModel>>(result);
                    if (data_.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        wardenDetail.GetWardenData(data_);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await App.Current.MainPage.DisplayAlert("HMS", "No Data found.", "OK");
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert("HMS", "Data Error", "OK");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS",ex.ToString(), "OK");
            }
        }
    }
}
