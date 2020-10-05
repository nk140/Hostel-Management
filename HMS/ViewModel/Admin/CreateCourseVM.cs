using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class CreateCourseVM : BaseViewModel, ISaveCourse
    {
        StudentService studentService;
        private CourseModel courseModel = new CourseModel();
        public CourseModel CourseModel
        {
            get
            {
                return courseModel;
            }
            set
            {
                courseModel = value;
                OnPropertyChanged("CourseModel");
            }
        }
        public ICommand SaveCourseCommand => new Command(OnSaveCourseCommand);
        public CreateCourseVM()
        {
            studentService = new StudentService((ISaveCourse)this);
        }
        public async void OnSaveCourseCommand()
        {
            if (string.IsNullOrEmpty(CourseModel.courseName) || CourseModel.courseName.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Course Name Required", "OK");
            else if (string.IsNullOrEmpty(CourseModel.code) || CourseModel.code.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Course Code Required", "OK");
            else
            {
                CourseModel.userId = App.userid;
                studentService.CreateCourse(CourseModel);
            }
        }
        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void Sucess(string result)
        {
            CourseModel = new CourseModel();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("CourseModel");
        }
    }
}
