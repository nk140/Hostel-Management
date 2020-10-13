using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ViewCourseVM : BaseViewModel, Icoursedetail, IDeleteCourse
    {
        StudentService StudentService;
        private ObservableCollection<CourseDetailModel> courseDetailModels = new ObservableCollection<CourseDetailModel>();
        private CourseDetailModel _OldDisciplinaryData;

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
        public ICommand TapCommand => new Command<CourseDetailModel>(OnTapCommand);
        public ViewCourseVM()
        {
            StudentService = new StudentService((Icoursedetail)this, (IDeleteCourse)this);
            StudentService.GetCourseList();
        }
        public async void OnEditCommand(CourseDetailModel obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditCourse(obj.userId, obj.courseId, obj.courseName, obj.code));
        }
        public async void OnDeleteCommand(CourseDetailModel obj)
        {
            StudentService.DeleteCourse(obj.courseId);
        }
        public async void OnTapCommand(CourseDetailModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(CourseDetailModel obj)
        {
            if (_OldDisciplinaryData == obj)
            {
                obj.Isbuttonvisible = !obj.Isbuttonvisible;
                UpdateProduct(obj);
            }
            else
            {
                if (_OldDisciplinaryData != null)
                {
                    foreach (var items in CourseDetailModels1)
                    {
                        if (_OldDisciplinaryData.courseName == items.courseName)
                        {
                            _OldDisciplinaryData.Isbuttonvisible = false;
                            UpdateProduct(_OldDisciplinaryData);
                            break;
                        }
                    }
                }
                obj.Isbuttonvisible = true;
                UpdateProduct(obj);
            }
            _OldDisciplinaryData = obj;
        }
        public void UpdateProduct(CourseDetailModel obj)
        {
            var index = CourseDetailModels1.IndexOf(obj);
            CourseDetailModels1.Remove(obj);
            CourseDetailModels1.Insert(index, obj);
        }
        public async void GetCourseList(ObservableCollection<CourseDetailModel> courseDetailModels)
        {
            CourseDetailModels1 = courseDetailModels;
            OnPropertyChanged("CourseDetailModels1");
        }

        public async void DeleteSucess(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            StudentService.GetCourseList();
        }

        public async void servicefailed(string result)
        {
            CourseDetailModels1.Clear();
            OnPropertyChanged("CourseDetailModels1");
        }
    }
    public class EditCourseVM : BaseViewModel, IEditCourse
    {
        StudentService studentService;
        private UpdateCourseModel updateCourse = new UpdateCourseModel();
        public UpdateCourseModel UpdateCourseModel
        {
            get
            {
                return updateCourse;
            }
            set
            {
                updateCourse = value;
                OnPropertyChanged("UpdateCourseModel");
            }
        }
        public ICommand UpdateCourseCommand => new Command(OnUpdateCourseCommand);
        public EditCourseVM(string userid,string courseid,string coursename,string coursecode)
        {
            UpdateCourseModel.userId = userid;
            UpdateCourseModel.courseId = courseid;
            UpdateCourseModel.courseName = coursename;
            UpdateCourseModel.code = coursecode;
            studentService = new StudentService((IEditCourse)this);
        }
        public async void OnUpdateCourseCommand()
        {
            if(string.IsNullOrEmpty(UpdateCourseModel.courseName) || UpdateCourseModel.courseName.Length==0)
                await App.Current.MainPage.DisplayAlert("HMS", "Course Name Required", "OK");
            else if (string.IsNullOrEmpty(UpdateCourseModel.code) || UpdateCourseModel.code.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Course Code Required", "OK");
            else
                studentService.UpdateCourse(UpdateCourseModel);
        }
        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void UpdateSucess(string result)
        {
            UpdateCourseModel = new UpdateCourseModel();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateCourseModel");
        }
    }
}
