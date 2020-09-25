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
    public partial class ViewFloor : ContentPage
    {
        ViewFloorVM vm;
        string id;
        string blockid;
        public ObservableCollection<FloorData> floorDatas;
        public ObservableCollection<FloorData> floorDatas1;
        public ViewFloor()
        {
            InitializeComponent();
        }
        public ViewFloor(string hostelid,string blockid)
        {
            InitializeComponent();
            id = hostelid;
            this.blockid = blockid;
            BindingContext = vm = new ViewFloorVM(hostelid,blockid);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewFloorVM(id, blockid);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyfloorname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    floorDatas = new ObservableCollection<FloorData>();
                    if (vm.FloorModelList != null)
                    {
                        foreach (var items in vm.FloorModelList)
                        {
                            if (!string.IsNullOrEmpty(items.floorNo))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyfloorname.Text))
                                {
                                    if (items.floorNo.ToUpper().StartsWith(txtsearchbyfloorname.Text.ToUpper()) || items.floorNo.ToLower().StartsWith(txtsearchbyfloorname.Text.ToLower()))
                                        floorDatas.Add(items);
                                }
                            }
                        }
                        txtsearchbyfloorname.ItemsSource = floorDatas;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyfloorname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyfloorname.Text = ((FloorData)e.SelectedItem).floorNo;
            if (floorDatas != null)
            {
                floorDatas1 = new ObservableCollection<FloorData>();
                foreach (var items in floorDatas)
                {
                    if (txtsearchbyfloorname.Text == items.floorNo)
                        floorDatas1.Add(items);
                }
                FloorDetaillists1.ItemsSource = floorDatas1;
            }
        }
    }
}