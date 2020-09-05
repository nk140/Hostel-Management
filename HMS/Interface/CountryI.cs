using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface CountryI
    {
        Task LoadCountry(ObservableCollection<CountryModel> countryList);
        Task LoadCountryFail();
        Task LoadStateList(ObservableCollection<StateModel> stateList);
        Task LoadStateListFail();
        Task LoadAreaList(ObservableCollection<AreaModel> areaList);
        Task LoadAreaListFail();
    }
}
