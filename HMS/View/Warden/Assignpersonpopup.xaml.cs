using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Guest;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assignpersonpopup : PopupPage,Iassignserviceperson
    {
        AssignServiceModel AssignServiceModel = new AssignServiceModel();
        WardenService wardenService;
        string requesttypeids;
        public Assignpersonpopup()
        {
            InitializeComponent();
            wardenService = new WardenService(this);
        }
        public Assignpersonpopup(string requesttypeid)
        {
            InitializeComponent();
            requesttypeids = requesttypeid;
            wardenService = new WardenService(this);
        }
        public void failer(string result)
        {
            DisplayAlert("HMS", result, "OK");
        }

        public void sucess(string result)
        {
            AssignServiceModel = new AssignServiceModel();
            txtpersonname.Text = "";
            txtjobtitle.Text = "";
            txtpersonphoneno.Text = "";
            DisplayAlert("HMS", result, "OK");
            Navigation.PopPopupAsync(true);
        }

        private void btnassign_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpersonname.Text) || txtpersonname.Text.Length == 0)
                DisplayAlert("HMS", "Person name required", "OK");
            else if (string.IsNullOrEmpty(txtjobtitle.Text) || txtjobtitle.Text.Length == 0)
                DisplayAlert("HMS", "job title required.", "OK");
            else if(string.IsNullOrEmpty(txtpersonphoneno.Text) || txtpersonphoneno.Text.Length==0)
                DisplayAlert("HMS", "Person Contact required", "OK");
            else if(txtpersonphoneno.Text.Length!=10)
                DisplayAlert("HMS", "Person Contact should have 10 digit", "OK");
            else
            {
                AssignServiceModel.requestPersonName = txtpersonname.Text;
                AssignServiceModel.requestPersonJobTitle = txtjobtitle.Text;
                AssignServiceModel.requestPersonPhoneNo = txtpersonphoneno.Text;
                wardenService.AssignServiceToPerson(AssignServiceModel, requesttypeids, App.userid);
            }
        }
    }
}