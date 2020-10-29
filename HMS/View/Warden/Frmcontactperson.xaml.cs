
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frmcontactperson : ContentPage
    {
        Requestedvehiclestudent requestedvehiclestudent;
        public Frmcontactperson()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            requestedvehiclestudent = new Requestedvehiclestudent();
            lv_contact.ItemsSource = requestedvehiclestudent.vehiclerequestedModels;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
    public class Requestedvehiclestudent
    {
        public IList<VehiclerequestedModel> vehiclerequestedModels { get; set; }
        public Requestedvehiclestudent()
        {
            vehiclerequestedModels = new List<VehiclerequestedModel>();
            vehiclerequestedModels.Add(new VehiclerequestedModel
            {
                studentName="Nitesh Kumar",
                StudentPhoneno="9078802809",
                requestedfor="Pickup",
                startlocation="Railway station",
                endlocation="Drems Boys Hostel",
                Datetime=DateTime.Now.ToString()
            });
            vehiclerequestedModels.Add(new VehiclerequestedModel
            {
                studentName = "Nimesh Kumar",
                StudentPhoneno = "9078802809",
                requestedfor = "Drop",
                startlocation = "Jk Boys Hostel",
                endlocation = "Kempodgeda International Airport",
                Datetime = DateTime.Now.ToString()
            });
        }
    }
    public class VehiclerequestedModel
    {
        public string studentName { get; set; }
        public string StudentPhoneno { get; set; }
        public string requestedfor { get; set; }
        public string startlocation { get; set; }
        public string endlocation { get; set; }
        public string Datetime { get; set; }
    }
}