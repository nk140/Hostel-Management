
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmRoomMateDetails : ContentPage
    {
        Roomatedetails roommatedetailsModel = new Roomatedetails();
        public FrmRoomMateDetails()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lstroomatedetails.ItemsSource = roommatedetailsModel.roommatedetailsModels;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
    public class Roomatedetails
    {
        public IList<RoommatedetailsModel> roommatedetailsModels { get; set; }
        public Roomatedetails()
        {
            roommatedetailsModels = new List<RoommatedetailsModel>();
            roommatedetailsModels.Add(new RoommatedetailsModel
            {
                name="Ratnesh kumar",
                bedno="bed02",
                contact="9988776677"
            });
            roommatedetailsModels.Add(new RoommatedetailsModel
            {
                name = "Nimesh kumar",
                bedno = "bed03",
                contact = "9988770945"
            });
        }
    }
    public class RoommatedetailsModel
    {
        public string name { get; set; }
        public string bedno { get; set; }
        public string contact { get; set; }
    }
}
