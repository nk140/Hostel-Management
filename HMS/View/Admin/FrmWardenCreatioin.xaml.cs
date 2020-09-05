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

            RoleModel md = (RoleModel)lv_role.SelectedItem;
            int cnt = Vm.Role.IndexOf(md);
            if (cnt >= 0)
            {
                Vm.RoleItemSelect(cnt);
            }

         ((ListView)sender).SelectedItem = null;
        }

        private void OnSelectedGenderItem(object sender, ItemTappedEventArgs e)
        {

            //    GenderModel md = (GenderModel)lv_gender.SelectedItem;
            //    int cnt = Vm.Gender.IndexOf(md);
            //    if (cnt >= 0)
            //    {
            //        Vm.GenderItemSelect(cnt);
            //    }

            //((ListView)sender).SelectedItem = null;
        }
    }
}
