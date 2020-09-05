using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ServiceCategoryVM : BaseViewModel, ServiceCategoryI
    {
        public ServiceCategoryVM()
        {
            web = new MasterServices(this);
            Category = new ServiceCategoryModel();
        }

        ServiceCategoryModel model;
        MasterServices web;



        public ServiceCategoryModel Category
        {
            get { return model; }
            set { model = value; OnPropertyChanged("Category"); }
        }





        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Category.name == null || Category.name.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Enter Category Name", "OK");
                    }
                    else
                    {
                        Category.userId = App.userid;
                        web.SaveServiceCategory(Category);
                    }
                });
            }
        }


        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("", result, "OK");
        }

        public async Task PostServiceCategorySuccess(string result)
        {
            await App.Current.MainPage.DisplayAlert("", result, "OK");
            Category.name = "";
            OnPropertyChanged("Category");
        }
    }
}
