namespace HMS.Interface
{
    public interface IDisciplinary
    {
        void SaveDisciplinaryType(string result);
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
