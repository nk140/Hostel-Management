﻿using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.Interface
{
    public interface IWardenDetail
    {
        void GetWardenData(ObservableCollection<WardenInfoModel> wardenModels);
    }
    public interface IViewDirectorDetail
    {
        void GetDirectorDetails(ObservableCollection<ViewDirectorDetails> viewDirectorDetails);
        void failer(string result);
    }
    public interface IEditWardenDetail
    {
        void updatesucessfully(string result);
        void servicefailed(string result);
    }
    public interface IDeleteWardenDetail
    {
        void Deletesucessfully(string result);
        void servicefailed(string result);
    }
    public interface IWardenAssignment
    {
        void SaveWardenassignment(string result);
        void servicefailed(string result);
    }
}
