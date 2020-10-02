using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface IDisciplinary
    {
        void SaveDisciplinaryType(string result);
    }
    public interface ViewIDisciplinary
    {
        void LoadDisciplinaryList(ObservableCollection<ViewDisciplinaryType> viewDisciplinaryTypes);
        void ServiceFailed(string result);
    }
    public interface IEditDisciplinary
    {
        void UpdateDisciplinaryType(string result);
        void Failer(string result);
    }
    public interface IDeleteDisciplinary
    {
        void DeleteDisciplinaryType(string result);
        void Failer(string result);
    }
}
