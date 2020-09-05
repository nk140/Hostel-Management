using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Inewsfeeddata
    {
        void Getnewsfeedlist(ObservableCollection<NewsFeed> newsFeeds);
        void Servicefailed();
    }
}
