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
        Iparent iparent;
        iUpdatePassword iupdatePassword;
        iviewchildleave iviewchildleave;
        Iviewchildhosteldetail iviewchildhosteldetail;
        public ParentService(IWardenDetail wardenDetaildata)
        {
            wardenDetail = wardenDetaildata;
        }
        public ParentService(Iviewchildhosteldetail callback)
        {
            iviewchildhosteldetail = callback;
        }
        public ParentService(Iparent callback)
        {
            iparent = callback;
        }
        public ParentService(iUpdatePassword iUpdatePassword)
        {
            this.iupdatePassword = iUpdatePassword;
        }
        public ParentService(iviewchildleave viewchildleave)
        {
            iviewchildleave = viewchildleave;
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
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void GetChildHostelData(string studentId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("studentId", studentId);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.Getchildhosteldetail);
                string result = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<ChildHostelDetailModel> data_ = JsonConvert.DeserializeObject<ObservableCollection<ChildHostelDetailModel>>(result);
                    if (data_.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        iviewchildhosteldetail.LoadChildHostelDetails(data_);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        iviewchildhosteldetail.servicefailed("No Data Found");
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
                iviewchildhosteldetail.servicefailed("It seems Your child is not done anything in wrong");
            }
        }
        public async void SaveParentDetail(ParentRegistration model)
        {
            ParentRegistrationResponse parentRegistrationResponse;
            ParentRegistrationErrorResponse parentRegistrationErrorResponse;
            string resultHostel;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.ParentRegistration, content);
                resultHostel = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    parentRegistrationResponse = JsonConvert.DeserializeObject<ParentRegistrationResponse>(resultHostel);
                    iparent.Success(parentRegistrationResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    parentRegistrationErrorResponse = JsonConvert.DeserializeObject<ParentRegistrationErrorResponse>(resultHostel);
                    iparent.servicefailed(parentRegistrationErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void SetPassword(UpdatePassword updatePassword)
        {
            UpdatePasswordResponse updatePasswordResponse;
            UpdatePasswordErrorResponse updatePasswordErrorResponse;
            string resultHostel;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updatePassword);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.UpdatePassword, content);
                resultHostel = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    updatePasswordResponse = JsonConvert.DeserializeObject<UpdatePasswordResponse>(resultHostel);
                    iupdatePassword.UpdatepasswordSuccess(updatePasswordResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    updatePasswordErrorResponse = JsonConvert.DeserializeObject<UpdatePasswordErrorResponse>(resultHostel);
                    iupdatePassword.servicefailed(updatePasswordErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void GetChildLeaveHistory()
        {

        }
    }
}
