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
        void requestedsucess(string result);
        void failer(string result);
    }
    public interface IEditservicecategory
    {
        void getallservicecategory(string result);
        void failer(string result);
    }
    public interface IDeleteservicecategory
    {
        void Deleteservicecategory(string result);
        void failer(string result);
    }
}
