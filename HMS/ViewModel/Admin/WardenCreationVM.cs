using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class WardenCreationVM : BaseViewModel, WardenCreatrI
    {
        bool _check1;
        public bool IsCheck1 { get { return _check1; } set { if (_check1 != value) { _check1 = value; OnPropertyChanged(); } } }
        bool _check2;
        public bool IsCheck2 { get { return _check2; } set { if (_check2 != value) { _check2 = value; OnPropertyChanged(); } } }
        #region commands
        public Command Check1Clicked { get; set; }
        public Command Check2Clicked { get; set; }
        #endregion
        public WardenCreationVM()
        {

            web = new MasterServices(this);
            web.GetAllRole();
            IsCheck1 = true;
            Check1Clicked = new Command(check1Clicked);
            Check2Clicked = new Command(check2Clicked);
            //Gender.Add(new GenderModel() { name = "Male" });
            //Gender.Add(new GenderModel() { name = "Female" });
        }


        MasterServices web;

        string RoleName_ = "";
        bool RoleVisible_ = false;
        long RoleHeight_ = 0;
        string GenderName_ = "";
        bool GenderVisible_ = false;
        long GenderHeight_ = 0;
        string confirmPassword_ = "";

        WardenModel warden_ = new WardenModel();
        ObservableCollection<RoleModel> Role_ = new ObservableCollection<RoleModel>();
        ObservableCollection<GenderModel> Gender_ = new ObservableCollection<GenderModel>();
        private void check2Clicked()
        {
            if (IsCheck2 == true)
                IsCheck1 = false;
            else
                IsCheck1 = true;
        }

        private void check1Clicked()
        {
            if (IsCheck1 == true)
            {

                IsCheck2 = false;

            }
            else
            {
                IsCheck2 = true;
            }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword_; }
            set { confirmPassword_ = value; OnPropertyChanged("ConfirmPassword"); }
        }

        public bool RoleVisible
        {
            get { return RoleVisible_; }
            set { RoleVisible_ = value; OnPropertyChanged("RoleVisible"); }
        }

        public long RoleHeight
        {
            get { return RoleHeight_; }
            set { RoleHeight_ = value; OnPropertyChanged("RoleHeight"); }
        }

        public string RoleName
        {
            get { return RoleName_; }
            set { RoleName_ = value; OnPropertyChanged("RoleName"); }
        }

        public bool GenderVisible
        {
            get { return GenderVisible_; }
            set { GenderVisible_ = value; OnPropertyChanged("GenderVisible"); }
        }

        public long GenderHeight
        {
            get { return GenderHeight_; }
            set { GenderHeight_ = value; OnPropertyChanged("GenderHeight"); }
        }

        public string GenderName
        {
            get { return GenderName_; }
            set { GenderName_ = value; OnPropertyChanged("GenderName"); }
        }

        public WardenModel Warden
        {
            get { return warden_; }
            set { warden_ = value; OnPropertyChanged("Warden"); }
        }

        public ObservableCollection<RoleModel> Role
        {
            get { return Role_; }
            set { Role_ = value; OnPropertyChanged("Role"); }

        }

        public ObservableCollection<GenderModel> Gender
        {
            get { return Gender_; }
            set { Gender_ = value; OnPropertyChanged("Gender"); }
        }


        public Command SetRoleVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (Role != null)
                    {
                        if (Role.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Role", "OK");
                            RoleVisible = false;
                        }
                        else
                        {
                            RoleHeight = (40 * Role.Count) + 20;
                            RoleVisible = !RoleVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Role", "OK");
                        RoleVisible = false;
                    }


                    OnPropertyChanged("Role");
                });
            }
        }

        public Command SetGenderVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (Gender != null)
                    {
                        if (Gender.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Gender", "OK");
                            GenderVisible = false;
                        }
                        else
                        {
                            GenderHeight = (40 * Gender.Count) + 20;
                            GenderVisible = !GenderVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Gender", "OK");
                        GenderVisible = false;
                    }


                    OnPropertyChanged("Gender");
                });
            }
        }

        public Command SaveWardenCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Validate())
                    {
                        web.SaveWarden(Warden);
                    }
                });
            }
        }

        bool Validate()
        {
            string emailpattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex emailRegx = new Regex(emailpattern);
            if (IsCheck1 == true)
            {
                Warden.gender = "Male";
            }
            else
            {
                Warden.gender = "Female";
            }
            if (Warden.firstName == null || Warden.firstName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Name", "OK");
                return false;
            }
            else if (Warden.permanent_address_line_1 == null || Warden.permanent_address_line_1.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Address", "OK");
                return false;
            }
            else if (Warden.permanent_address_city == null || Warden.permanent_address_city.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter City", "OK");
                return false;
            }
            else if (Warden.mobile_no == null || Warden.mobile_no.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Phone Number", "OK");
                return false;
            }
            else if (Warden.mobile_no.Length != 10)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Phone Number Must Be 10 digits", "OK");
                return false;
            }
            else if (Warden.email == null || Warden.email.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Email Id", "OK");
                return false;
            }
            else if (RoleName.Length == 0 || string.IsNullOrEmpty(RoleName))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Role", "OK");
                return false;
            }
            else if (Warden.gender == null || Warden.gender.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Select Gender", "OK");
                return false;
            }
            else if(Warden.roleId==null || Warden.roleId.Length==0)
            {
                App.Current.MainPage.DisplayAlert("", "Select Role", "OK");
                return false;
            }
            else if (Warden.email == null || Warden.email.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Email Address", "OK");
                return false;
            }
            else if (emailRegx.IsMatch(Warden.email) == false)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Valid Email Address", "OK");
                return false;
            }
            else if (Warden.username == null || Warden.username.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Username", "OK");
                return false;
            }
            else if (Warden.password == null || Warden.password.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Passwoord", "OK");
                return false;
            }
            else if (ConfirmPassword == null || Warden.password.ToString().Trim() != ConfirmPassword)
            {
                App.Current.MainPage.DisplayAlert("", "Password and Confirm Password is missmatch", "OK");
                return false;
            }


            return true;
        }


        public void RoleItemSelect(int index)
        {
            Warden.roleId = Role[index].roleId.ToString();
            RoleName = Role[index].roleName;
            RoleVisible = false;
            OnPropertyChanged("RoleVisible");
            OnPropertyChanged("RoleName");
        }

        public void GenderItemSelect(int index)
        {
            Warden.gender = Gender[index].name;
            GenderVisible = false;
            OnPropertyChanged("GenderVisible");
            OnPropertyChanged("Warden");
        }

        public async Task ServiceFaild()
        {
            await App.Current.MainPage.DisplayAlert("HMS", "Something Went wrong.", "OK");
        }

        public async Task GetAllRole(ObservableCollection<RoleModel> role_)
        {
            Role = new ObservableCollection<RoleModel>();
            if (role_ != null)
            {
                foreach(var items in role_)
                {
                    if (items.roleName == "warden")
                    {
                        Role.Add(items);
                        break;
                    }
                        
                }
            }
            //Role = role_;
            OnPropertyChanged("Role");
        }

        public async Task SaveWarden(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            Warden = new WardenModel();
            ConfirmPassword = "";
            RoleName = "";
            IsCheck1 = true;
            OnPropertyChanged("Warden");
            OnPropertyChanged("ConfirmPassword");
        }
    }
}
