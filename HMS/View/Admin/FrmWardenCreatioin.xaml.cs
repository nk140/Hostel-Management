using HMS.Models;
using HMS.ViewModel.Admin;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmWardenCreatioin : ContentPage
    {
        public FrmWardenCreatioin()
        {
            InitializeComponent();
        }

        WardenCreationVM Vm;

        protected override void OnAppearing()
        {
            Vm = new WardenCreationVM();
            BindingContext = Vm;
        }

        private void OnSelectedRoleItem(object sender, ItemTappedEventArgs e)
        {
            //rolemodel md = (rolemodel)lv_role.selecteditem;
            //int cnt = vm.role.indexof(md);
            //if (cnt >= 0)
            //{
            //    vm.roleitemselect(cnt);
            //}
            //((listview)sender).selecteditem = null;
        }

        private void dp_dob_Unfocused(object sender, FocusEventArgs e)
        {
            Vm.Warden.dateOfBirth = dp_dob.Date.ToShortDateString();
        }

        private void dp_dob_DateSelected(object sender, DateChangedEventArgs e)
        {
            Vm.Warden.dateOfBirth = dp_dob.Date.ToShortDateString();
        }
    }
}
