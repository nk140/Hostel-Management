using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Inewstudentdata
    {
        void GetNewStudentData(ObservableCollection<Students> students);
    }
}
