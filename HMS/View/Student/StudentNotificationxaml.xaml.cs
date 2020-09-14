using HMS.ViewModel.Student;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentNotificationxaml : PopupPage
    {
        NotificationVM vm;
        public StudentNotificationxaml()
        {
            InitializeComponent();
            BindingContext = vm = new NotificationVM();
        }
    }
}