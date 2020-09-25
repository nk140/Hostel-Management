using HMS.Models;
using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditArea : ContentPage
    {
        EditAreaVM vm;
        public ObservableCollection<CountryModel> countryModels;
        public ObservableCollection<StateModel> stateModels;
        public EditArea(string areaid,string areaname,string stateid)
        {
            InitializeComponent();
            BindingContext = vm = new EditAreaVM(areaid,areaname,stateid);
        }
    }
}