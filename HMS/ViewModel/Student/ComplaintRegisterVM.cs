using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class ComplaintRegisterVM : BaseViewModel
    {
        public ComplaintRegisterVM()
        {

        }


        public string ComplaintType_ = "", Complaint_ = "";

        public string ComplaintType
        {
            get { return ComplaintType_; }
            set { ComplaintType_ = value; OnPropertyChanged("ComplaintType"); }
        }

        public string Complaint
        {
            get { return Complaint_; }
            set { Complaint_ = value; OnPropertyChanged("Complaint"); }
        }


        public Command Save
        {
            get
            {
                return new Command(() =>
                {
                    if (ComplaintType.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Enter Complaint Type ", "OK");
                    }
                    else if (Complaint.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Enter Complaint", "OK");
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "Data Saved", "OK");
                        ComplaintType = "";
                        Complaint = "";
                        OnPropertyChanged("ComplaintType");
                        OnPropertyChanged("Complaint");
                    }
                });
            }
        }
    }
}
