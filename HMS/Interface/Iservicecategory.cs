using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.Interface
{
    public interface Iservicecategory
    {
        void getallservicecategory(ObservableCollection<WardenServiceModel> wardenServiceModels);
    }
}
