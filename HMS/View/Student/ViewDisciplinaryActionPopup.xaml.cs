using Rg.Plugins.Popup.Extensions;
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
    public partial class ViewDisciplinaryActionPopup : PopupPage
    {
        public ViewDisciplinaryActionPopup()
        {
            InitializeComponent();
        }
        public ViewDisciplinaryActionPopup(string date,string time,string studentname,string regno,string disciplinarytype,string description)
        {
            InitializeComponent();
            txtDate.Text = date;
            txttime.Text = time;
            txtstudentname.Text = studentname;
            txtstudentregno.Text = regno;
            txtdisciplinarytype.Text = disciplinarytype;
            txtdescription.Text = description;
        }
        private async void btnclose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
    }
}