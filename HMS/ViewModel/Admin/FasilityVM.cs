using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class FasilityVM : BaseViewModel, FasilityI
    {
        public FasilityVM()
        {
            web = new MasterServices(this);
            FasilityData = new FasilityModel();
        }


        FasilityModel fasilityModel = new FasilityModel();
        MasterServices web;

        public FasilityModel FasilityData
        {
            get { return fasilityModel; }
            set { fasilityModel = value; OnPropertyChanged("FasilityData"); }
        }

        public Command SaveData
        {
            get
            {
                return new Command(() =>
                {
                    if (FasilityData.name == null || FasilityData.name.Length == 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        App.Current.MainPage.DisplayAlert("HMS", "Please Enter Facility", "OK");
                    }
                    else
                    {
                        web.SaveFasility(FasilityData);
                    }
                });
            }
        }

        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("", "Something went wrong", "OK");
        }

        public async Task PostFasilitySuccess(string resultHostel)
        {
            FasilityData.name = string.Empty;
            await App.Current.MainPage.DisplayAlert("", resultHostel, "OK");
            OnPropertyChanged("FasilityData");
        }
    }
}
