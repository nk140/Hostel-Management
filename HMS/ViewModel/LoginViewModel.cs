using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.Utils;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel
{
    public class LoginViewModel : BaseViewModel, LoginI
    {
        public LoginViewModel(NavigationPageI pageI)
        {
            navigationPage = pageI;
            webService = new LoginServices(this);
            UserModel = new UserModel();
            UserModel.userName = "";
            UserModel.password = "";
        }
        NavigationPageI navigationPage;
        LoginServices webService;
        private UserModel userModel_ = new UserModel();
        public UserModel UserModel
        {
            get { return userModel_; }
            set { userModel_ = value; OnPropertyChanged("UserModel"); }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    Login();
                });
            }
        }
        private async void Login()
        {

            if (UserModel.userName.Length > 0 && UserModel.password.Length > 0)
            {
                UserDialogs.Instance.ShowLoading(null, MaskType.Gradient);
                webService.UserLogin(UserModel);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please enter Username and Password", "OK");
            }
        }
        public async void UserLoginSuccess(UserModel userData)
        {
            Constants.UserName = UserModel.userName;
            Constants.UserId = UserModel.userId;
            UserModel = userData;
            if (UserModel.userType != null)
            {
                //if (UserModel.userType == "warden")
                //{
                //    UserDialogs.Instance.HideLoading();
                //    await SecureStorage.SetAsync("userId", userData.userId.ToString());
                //    await SecureStorage.SetAsync("type", userData.userType);
                //    await SecureStorage.SetAsync("id", UserModel.id.ToString());
                //    await SecureStorage.SetAsync("firstName", UserModel.firstName);
                //    if (UserModel.studentId != null)
                //        await SecureStorage.SetAsync("studentId", UserModel.studentId);
                //    else
                //    {

                //    }
                //    if (UserModel.hostelId != null)
                //        await SecureStorage.SetAsync("hostelId", UserModel.studentId);
                //    else
                //    {

                //    }
                //    if (UserModel.areaId != null)
                //        await SecureStorage.SetAsync("areaId", UserModel.studentId);
                //    else
                //    {

                //    }
                //    if (UserModel.dateOfBirth != null)
                //        await SecureStorage.SetAsync("dateOfBirth", UserModel.dateOfBirth);
                //    else
                //    {

                //    }
                //    if (UserModel.dateOfJoining != null)
                //        await SecureStorage.SetAsync("dateOfJoining", UserModel.dateOfJoining);
                //    else
                //    {

                //    }
                //    if (UserModel.permanent_address_line_1 != null)
                //        await SecureStorage.SetAsync("permanent_address_line_1", UserModel.permanent_address_line_1);
                //    else
                //    {

                //    }
                //    if (UserModel.permanent_address_line_2 != null)
                //        await SecureStorage.SetAsync("permanent_address_line_2", UserModel.permanent_address_line_2);
                //    else
                //    {

                //    }
                //    if (UserModel.permanent_address_city != null)
                //        await SecureStorage.SetAsync("permanent_address_city", UserModel.permanent_address_city);
                //    else
                //    {

                //    }
                //    if (UserModel.email != null)
                //        await SecureStorage.SetAsync("email", UserModel.email);
                //    else
                //    {

                //    }
                //    if (UserModel.mobile_no != null)
                //        await SecureStorage.SetAsync("mobile_no", UserModel.mobile_no);
                //    else
                //    {

                //    }
                //    if (UserModel.blood_group != null)
                //        await SecureStorage.SetAsync("blood_group", UserModel.blood_group);
                //    else
                //    {

                //    }
                //    if (UserModel.gender != null)
                //        await SecureStorage.SetAsync("gender", UserModel.gender);
                //    else
                //    {

                //    }
                //    await navigationPage.NavigateHomeForm();
                //}
                if (UserModel.userType == "parent")
                {
                    UserDialogs.Instance.HideLoading();
                    await SecureStorage.SetAsync("userId", userData.userId.ToString());
                    await SecureStorage.SetAsync("type", userData.userType);
                    await SecureStorage.SetAsync("id", UserModel.id.ToString());
                    await SecureStorage.SetAsync("firstName", UserModel.firstName);
                    if (UserModel.hostelAdmisiionId != null)
                        await SecureStorage.SetAsync("hostelAdmisiionId", UserModel.hostelAdmisiionId);
                    else
                    {

                    }
                    if (UserModel.studentId != null)
                        await SecureStorage.SetAsync("studentId", UserModel.studentId);
                    else
                    {

                    }
                    if (UserModel.dateOfBirth != null)
                        await SecureStorage.SetAsync("dateOfBirth", UserModel.dateOfBirth);
                    else
                    {

                    }
                    if (UserModel.dateOfJoining != null)
                        await SecureStorage.SetAsync("dateOfJoining", UserModel.dateOfJoining);
                    else
                    {

                    }
                    if (UserModel.permanent_address_line_1 != null)
                        await SecureStorage.SetAsync("permanent_address_line_1", UserModel.permanent_address_line_1);
                    else
                    {

                    }
                    if (UserModel.permanent_address_line_2 != null)
                        await SecureStorage.SetAsync("permanent_address_line_2", UserModel.permanent_address_line_2);
                    else
                    {

                    }
                    if (UserModel.permanent_address_city != null)
                        await SecureStorage.SetAsync("permanent_address_city", UserModel.permanent_address_city);
                    else
                    {

                    }
                    if (UserModel.email != null)
                        await SecureStorage.SetAsync("email", UserModel.email);
                    else
                    {

                    }
                    if (UserModel.mobile_no != null)
                        await SecureStorage.SetAsync("mobile_no", UserModel.mobile_no);
                    else
                    {

                    }
                    if (UserModel.blood_group != null)
                        await SecureStorage.SetAsync("blood_group", UserModel.blood_group);
                    else
                    {

                    }
                    if (UserModel.gender != null)
                        await SecureStorage.SetAsync("gender", UserModel.gender);
                    else
                    {

                    }
                    if (UserModel.wardenDisciplinaryId != null)
                    {
                        await SecureStorage.SetAsync("wardenDisciplinaryId", UserModel.wardenDisciplinaryId);
                    }
                    else
                    {

                    }
                    if (UserModel.disciplinaryName != null)
                    {
                        await SecureStorage.SetAsync("disciplinaryName", UserModel.disciplinaryName);
                    }
                    else
                    {

                    }
                    if (UserModel.studentName != null)
                    {
                        await SecureStorage.SetAsync("studentName", UserModel.studentName);
                    }
                    else
                    {

                    }
                    if (UserModel.date != null)
                    {
                        await SecureStorage.SetAsync("date", UserModel.date);
                    }
                    else
                    {

                    }
                    if (UserModel.time != null)
                    {
                        await SecureStorage.SetAsync("time", UserModel.time);
                    }
                    else
                    {

                    }
                    if (UserModel.applicationNo != null)
                    {
                        await SecureStorage.SetAsync("applicationNo", UserModel.applicationNo);
                    }
                    else
                    {

                    }
                    await navigationPage.NavigateHomeForm();
                }
                else if (UserModel.userType == "guest")
                {
                    UserDialogs.Instance.HideLoading();
                    if (UserModel.userId != 0)
                        await SecureStorage.SetAsync("userId", userData.userId.ToString());
                    else
                    {

                    }
                    if (UserModel.userType != null)
                        await SecureStorage.SetAsync("type", userData.userType);
                    else
                    {

                    }
                    if (UserModel.id != 0)
                        await SecureStorage.SetAsync("id", UserModel.id.ToString());
                    else
                    {

                    }
                    if (UserModel.firstName != null)
                        await SecureStorage.SetAsync("firstName", UserModel.firstName);
                    else
                    {

                    }
                    if (UserModel.dateOfBirth != null)
                        await SecureStorage.SetAsync("dateOfBirth", UserModel.dateOfBirth);
                    else
                    {

                    }
                    if (UserModel.permanent_address_city != null)
                        await SecureStorage.SetAsync("permanent_address_city", UserModel.permanent_address_city);
                    else
                    {

                    }
                    if (UserModel.permanent_address_line_1 != null)
                        await SecureStorage.SetAsync("permanent_address_line_1", UserModel.permanent_address_line_1);
                    else
                    {

                    }
                    if (UserModel.permanent_address_line_2 != null)
                        await SecureStorage.SetAsync("permanent_address_line_2", UserModel.permanent_address_line_2);
                    else
                    {

                    }
                    if (UserModel.email != null)
                        await SecureStorage.SetAsync("email", UserModel.email);
                    else
                    {

                    }
                    if (UserModel.mobile_no != null)
                        await SecureStorage.SetAsync("mobile_no", UserModel.mobile_no);
                    else
                    {

                    }
                    if (UserModel.blood_group != null)
                        await SecureStorage.SetAsync("blood_group", UserModel.blood_group);
                    else
                    {

                    }
                    if (UserModel.gender != null)
                        await SecureStorage.SetAsync("gender", UserModel.gender);
                    else
                    {

                    }
                    await navigationPage.NavigateHomeForm();
                }
                else if (UserModel.userType == "admin")
                {
                    UserDialogs.Instance.HideLoading();
                    await SecureStorage.SetAsync("userId", userData.userId.ToString());
                    await SecureStorage.SetAsync("type", userData.userType);
                    await navigationPage.NavigateHomeForm();
                }
            }
            else
            {
                //await SecureStorage.SetAsync("userId", UserModel.userId.ToString());
                //await SecureStorage.SetAsync("id", UserModel.id.ToString());
                //await SecureStorage.SetAsync("firstName", UserModel.firstName);
                //await SecureStorage.SetAsync("dateOfBirth", UserModel.dateOfBirth);
                //if (UserModel.dateOfJoining != null)
                //    await SecureStorage.SetAsync("dateOfJoining", UserModel.dateOfJoining);
                //else
                //{

                //}
                //if (UserModel.permanent_address_line_1 != null)
                //    await SecureStorage.SetAsync("permanent_address_line_1", UserModel.permanent_address_line_1);
                //else
                //{

                //}
                //if (UserModel.permanent_address_line_2 != null)
                //    await SecureStorage.SetAsync("permanent_address_line_2", UserModel.permanent_address_line_2);
                //else
                //{

                //}
                //if (UserModel.permanent_address_city != null)
                //    await SecureStorage.SetAsync("permanent_address_city", UserModel.permanent_address_city);
                //else
                //{

                //}
                //if (UserModel.email != null)
                //    await SecureStorage.SetAsync("email", UserModel.email);
                //else
                //{

                //}
                //if (UserModel.mobile_no != null)
                //    await SecureStorage.SetAsync("mobile_no", UserModel.mobile_no);
                //else
                //{

                //}
                //if (UserModel.blood_group != null)
                //    await SecureStorage.SetAsync("blood_group", UserModel.blood_group);
                //else
                //{

                //}
                //if (UserModel.gender != null)
                //    await SecureStorage.SetAsync("gender", UserModel.gender);
                //else
                //{

                //}
                //UserDialogs.Instance.HideLoading();
                //await navigationPage.NavigateHomeForm();
            }
        }
        public async void StudentLoginSucess(StudentModel studentModel)
        {
            UserDialogs.Instance.HideLoading();
            await SecureStorage.SetAsync("userId", studentModel.id.ToString());
            await SecureStorage.SetAsync("type", studentModel.userType);
            await SecureStorage.SetAsync("studentName", studentModel.studentName);
            await SecureStorage.SetAsync("email", studentModel.email);
            await SecureStorage.SetAsync("mobileNo", studentModel.mobileNo);
            if (studentModel.applicationNo != null)
            {
                await SecureStorage.SetAsync("applicationNo", studentModel.applicationNo);
            }
            else
            {

            }
            if (studentModel.wardenDisciplinaryId != null)
            {
                await SecureStorage.SetAsync("wardenDisciplinaryId", studentModel.wardenDisciplinaryId);
            }
            else
            {

            }
            if (studentModel.disciplinaryName != null)
            {
                await SecureStorage.SetAsync("disciplinaryName", studentModel.disciplinaryName);
            }
            else
            {

            }
            if (studentModel.date != null)
            {
                await SecureStorage.SetAsync("date", studentModel.date);
            }
            else
            {

            }
            if (studentModel.time != null)
            {
                await SecureStorage.SetAsync("time", studentModel.time);
            }
            else
            {

            }
            await navigationPage.NavigateHomeForm();
        }
        
        public Task ProccessFailed()
        {
            throw new NotImplementedException();
        }

        public async void WardenLoginsucess(WardenModels wardenModel)
        {
            UserDialogs.Instance.HideLoading();
            await SecureStorage.SetAsync("userId", wardenModel.userId.ToString());
            await SecureStorage.SetAsync("type", wardenModel.userType);
            await SecureStorage.SetAsync("employeeId", wardenModel.employeeId.ToString());
            await SecureStorage.SetAsync("wardenName", wardenModel.wardenName);
            if (wardenModel.hostelId != null)
                await SecureStorage.SetAsync("hostelId", wardenModel.hostelId);
            else
            {

            }
            if (wardenModel.hostelName != null)
                await SecureStorage.SetAsync("hostelName", wardenModel.hostelName);
            else
            {

            }
            if (wardenModel.dateOfBirth != null)
                await SecureStorage.SetAsync("dateOfBirth", wardenModel.dateOfBirth);
            else
            {

            }
            if (wardenModel.dateOfJoining != null)
                await SecureStorage.SetAsync("dateOfJoining", wardenModel.dateOfJoining);
            else
            {

            }
            if (wardenModel.permanent_address_line_1 != null)
                await SecureStorage.SetAsync("permanent_address_line_1", wardenModel.permanent_address_line_1);
            else
            {

            }
            if (wardenModel.permanent_address_line_2 != null)
                await SecureStorage.SetAsync("permanent_address_line_2", wardenModel.permanent_address_line_2);
            else
            {

            }
            if (wardenModel.permanent_address_city != null)
                await SecureStorage.SetAsync("permanent_address_city", wardenModel.permanent_address_city);
            else
            {

            }
            if (wardenModel.wardenEmail != null)
                await SecureStorage.SetAsync("wardenEmail", wardenModel.wardenEmail);
            else
            {

            }
            if (wardenModel.wardenPhoneNo != null)
                await SecureStorage.SetAsync("wardenPhoneNo", wardenModel.wardenPhoneNo);
            else
            {

            }
            if (wardenModel.blood_group != null)
                await SecureStorage.SetAsync("blood_group", wardenModel.blood_group);
            else
            {

            }
            if (wardenModel.wardenGender != null)
                await SecureStorage.SetAsync("wardenGender", wardenModel.wardenGender);
            else
            {

            }
            if (wardenModel.areaId != null)
            {
                await SecureStorage.SetAsync("areaId", wardenModel.areaId);
            }
            else
            {

            }
            if (wardenModel.areaName != null)
            {
                await SecureStorage.SetAsync("areaName", wardenModel.areaName);
            }
            else
            {

            }
            await navigationPage.NavigateHomeForm();
        }
    }
}
