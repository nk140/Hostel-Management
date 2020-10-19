﻿using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Utils;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace HMS.Services
{
    public class LoginServices
    {
        LoginI loginEvent;
        iforgetpassword iforgetpassword;
        public LoginServices(LoginI login)
        {
            loginEvent = login;
        }
        public LoginServices(iforgetpassword forgetpassword)
        {
            iforgetpassword = forgetpassword;
        }
        public async void ForgetPassword()
        {

        }
        public async void UserLogin(UserModel userModel_)
        {
            UserModel userModel;
            StudentModel studentModel;
            WardenModels wardenModel;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = @"{""userName"" : """ + userModel_.userName.ToString() + @""",""password"" : """ + userModel_.password + @"""}";

                //string jsn = @"{""userName"" : ""sabarmathi"",""password"" : ""christ@2019""}";

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.LOGIN, content);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    userModel = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
                    if(userModel.userType==null)
                    {
                        UserDialogs.Instance.HideLoading();
                        await App.Current.MainPage.DisplayAlert("HMS", "User doesn't exists.", "OK");
                    }
                    else if (userModel.userType == "student")
                    {
                        UserDialogs.Instance.HideLoading();
                        userModel = new UserModel();
                        studentModel = JsonConvert.DeserializeObject<StudentModel>(await response.Content.ReadAsStringAsync());
                        loginEvent.StudentLoginSucess(studentModel);
                    }
                    else if (userModel.userType == "warden")
                    {
                        UserDialogs.Instance.HideLoading();
                        userModel = new UserModel();
                        wardenModel = JsonConvert.DeserializeObject<WardenModels>(await response.Content.ReadAsStringAsync());
                        loginEvent.WardenLoginsucess(wardenModel);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        loginEvent.UserLoginSuccess(userModel);
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert(" ", "Incorrect Username or Password", "OK");
                    //Console.WriteLine("Incorrect Username or Password");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }
            //return response;
        }
    }
}
