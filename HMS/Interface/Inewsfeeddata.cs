using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Inewsfeeddata
    {
        void Getnewsfeedlist(ObservableCollection<NewsFeed> newsFeeds);
        void Servicefailed();
    }
    public interface IEditnewsfeeddata
    {
        void UpdateNewsFeed(string result);
        void Servicefailed(string result);
    }
    public interface IDeletenewsfeeddata
    {
        void Deletenewsfeedlist(string result);
        void Servicefailed(string result);
    }
}
