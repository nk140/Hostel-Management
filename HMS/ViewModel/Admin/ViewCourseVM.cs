using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ViewCourseVM : BaseViewModel, Icoursedetail,IDeleteCourse
    {
        StudentService StudentService;
        private ObservableCollection<CourseDetailModel> courseDetailModels = new ObservableCollection<CourseDetailModel>();
        public ObservableCollection<CourseDetailModel> CourseDetailModels1
        {
            get
            {
                return courseDetailModels;
            }
            set
            {
                courseDetailModels = value;
                OnPropertyChanged("CourseDetailModels1");
            }
        }
        public ICommand EditCommand => new Command<CourseDetailModel>(OnEditCommand);
        public ICommand DeleteCommand => new Command<CourseDetailModel>(OnDeleteCommand);
        public ViewCourseVM()
        {
            StudentService = new StudentService((Icoursedetail)this, (IDeleteCourse)this);
            StudentService.GetCourseList();
        }
        public async void OnEditCommand(CourseDetailModel obj)
        {

        }
        public async void OnDeleteCommand(CourseDetailModel obj)
        {

        }
        public async void GetCourseList(ObservableCollection<CourseDetailModel> courseDetailModels)
        {
            CourseDetailModels1 = courseDetailModels;
            OnPropertyChanged("CourseDetailModels1");
        }

        public async void DeleteSucess(string result)
        {
            
        }

        public async void servicefailed(string result)
        {
           
        }
    }
}
