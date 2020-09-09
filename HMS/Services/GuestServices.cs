using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HMS.Services
{
    public class GuestServices
    {
        IGuestRegistration guestRegistration;
        public GuestServices(IGuestRegistration GuestRegistration)
        {
            guestRegistration = GuestRegistration;
        }
        public async void SaveGuestData(GuestRegistrationModel guestRegistrationModel)
        {
            GuestRegResponse guestRegResponse;
            GuestRegErrorResponse guestRegErrorResponse;
            string resultHostel;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(guestRegistrationModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.GuestRegistration, content);
                resultHostel = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    guestRegResponse = JsonConvert.DeserializeObject<GuestRegResponse>(resultHostel);
                    guestRegistration.Success(guestRegResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    guestRegErrorResponse = JsonConvert.DeserializeObject<GuestRegErrorResponse>(resultHostel);
                    await App.Current.MainPage.DisplayAlert("HMS", guestRegErrorResponse.errors[0].message,"OK");
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
