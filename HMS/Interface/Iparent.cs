using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.Interface
{
    public interface Iparent
    {
        void Success(string result);
        void servicefailed(string result);
    }
    public interface iViewParent
    {
        void LoadParentData(ObservableCollection<StudentParentDetail> studentParentDetails);
        void Servicefailed(string result);
    }
    public interface iEditParentInfo
    {
        void Success(string result);
        void servicefailed(string result);
    }
    public interface iDeleteParentInfo
    {
        void DeleteSuccess(string result);
        void servicefailed(string result);
    }
    public interface iUpdatePassword
    {
        void UpdatepasswordSuccess(string result);
        void servicefailed(string result);
    }
    public interface iviewchildleave
    {
        void Loadchildleavelist(ObservableCollection<childleavehistory> childleavehistories);
        void servicefailed(string result);
    }
}
