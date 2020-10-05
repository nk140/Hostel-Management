using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.Interface
{
    public interface Icoursedetail
    {
        void GetCourseList(ObservableCollection<CourseDetailModel> courseDetailModels);
    }
    public interface ISaveCourse
    {
        void Sucess(string result);
        void servicefailed(string result);
    }
    public interface IEditCourse
    {
        void UpdateSucess(string result);
        void servicefailed(string result);
    }
    public interface IDeleteCourse
    {
        void DeleteSucess(string result);
        void servicefailed(string result);
    }
}
