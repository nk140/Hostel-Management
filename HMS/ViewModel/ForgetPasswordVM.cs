using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.ViewModel
{
    public class ForgetPasswordVM : BaseViewModel
    {
        private string emailaddress;
        public string EmailAddress
        {
            get
            {
                return emailaddress;
            }
            set
            {
                emailaddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }
        public ForgetPasswordVM()
        {

        }
    }
}
