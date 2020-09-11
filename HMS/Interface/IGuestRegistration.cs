using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.Interface
{
    public interface IGuestRegistration
    {
        void Success(string result);
    }
    public interface IWardenData
    {
        void WardenDetail(ObservableCollection<WardenInfoModel> wardenInfoModels);
    }
}
