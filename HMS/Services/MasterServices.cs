using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace HMS.Services
{
    public class MasterServices
    {

        CountryI countryCallback;
        AreaI areaCallback;
        EditAreaI editArea;
        DeleteAreaI deleteAreaI;
        EditHostelI editHostel;
        DeleteHostelI deleteHostelI1;
        HostelI hostelCallback;
        MasterI masterCallback;
        BlockI blockCallback;
        EditBlockI editBlockI;
        DeleteBlockI DeleteBlockI;
        ServiceCategoryI categoryCallback;
        FasilityI fasilityCallback;
        ViewFacilityI viewFacilityI;
        EditFasilityI editFasilityI;
        DeleteFasilityI deleteFasilityI;
        FloorI floorCallback;
        EditFloorI flooredit;
        DeleteFloorI deleteFloor;
        RoomI roomCallback;
        EditRoomI editRoomI;
        DeleteRoomI deleteRoomI;
        EditRoomTypeI EditRoomTypeI;
        DeleteRoomTypeI DeleteRoomTypeI;
        RoomListI roomListI;
        EditRoomBedI roomBedI;
        DeleteRoomBedI DeleteRoomBedI;
        RoomBedI roomBedCallback;
        RoomBedI1 roomBed;
        RoomListI1 roomListCallback;
        WardenCreatrI wardenCallback;
        IDisciplinary disciplinary;
        ViewIDisciplinary ViewIDisciplinary;
        IEditDisciplinary editDisciplinary;
        IDeleteDisciplinary deleteDisciplinary;
        IEditnewsfeeddata editnewsfeeddata;
        IDeletenewsfeeddata deletenewsfeeddata;
        IEditservicecategory editservicecategory;
        IDeleteservicecategory deleteservicecategory;
        IWardenAssignment iwardenAssignment;
        public MasterServices(RoomListI1 callback)
        {
            roomListCallback = callback;
        }
        public MasterServices(IEditDisciplinary callback)
        {
            editDisciplinary = callback;
        }
        public MasterServices(ViewIDisciplinary view, IDeleteDisciplinary callback)
        {
            ViewIDisciplinary = view;
            deleteDisciplinary = callback;
        }
        public MasterServices(ViewIDisciplinary view)
        {
            ViewIDisciplinary = view;
        }
        public MasterServices(IEditnewsfeeddata callback)
        {
            editnewsfeeddata = callback;
        }
        public MasterServices(IDeletenewsfeeddata callback)
        {
            deletenewsfeeddata = callback;
        }
        public MasterServices(IEditservicecategory callback)
        {
            editservicecategory = callback;
        }
        public MasterServices(EditFasilityI callback)
        {
            editFasilityI = callback;
        }
        public MasterServices(ViewFacilityI view, DeleteFasilityI callback)
        {
            viewFacilityI = view;
            deleteFasilityI = callback;
        }
        public MasterServices(MasterI master, EditRoomTypeI callback)
        {
            this.masterCallback = master;
            EditRoomTypeI = callback;
        }
        public MasterServices(RoomI room, DeleteRoomTypeI callback)
        {
            roomCallback = room;
            DeleteRoomTypeI = callback;
        }
        public MasterServices(IDeleteservicecategory callback)
        {
            deleteservicecategory = callback;
        }
        public MasterServices(MasterI masters,IWardenAssignment wardenassignment)
        {
            this.masterCallback = masters;
            iwardenAssignment = wardenassignment;
        }
        public MasterServices(RoomListI roomListI, DeleteRoomI deleteRoomI)
        {
            // this.masterCallback = master;
            this.roomListI = roomListI;
            this.deleteRoomI = deleteRoomI;
        }
        public MasterServices(RoomListI roomListI)
        {
            // this.masterCallback = master;
            this.roomListI = roomListI;
        }
        public MasterServices(MasterI masters,RoomListI roomListI)
        {
            this.masterCallback = masters;
            this.roomListI = roomListI;
        }
        public MasterServices(RoomBedI1 master, DeleteRoomBedI deleteRoomBedI)
        {
            roomBed = master;
            this.DeleteRoomBedI = deleteRoomBedI;
        }
        public MasterServices(RoomBedI1 master, MasterI masters, FloorI floor)
        {
            roomBed = master;
            masterCallback = masters;
            floorCallback = floor;
        }
        public MasterServices(EditRoomBedI editRoomBedI)
        {
            roomBedI = editRoomBedI;
        }
        public MasterServices(EditRoomI editRoomI)
        {
            // this.masterCallback = master;
            // this.roomListI = roomListI;
            this.editRoomI = editRoomI;
        }
        public MasterServices(MasterI master, EditHostelI editHosteli)
        {
            this.masterCallback = master;
            editHostel = editHosteli;
        }
        public MasterServices(MasterI master, DeleteHostelI deleteHostelI)
        {
            this.masterCallback = master;
            deleteHostelI1 = deleteHostelI;
        }
        public MasterServices(CountryI countryI, AreaI areaI)
        {
            this.countryCallback = countryI;
            this.areaCallback = areaI;
        }
        public MasterServices(CountryI country, EditAreaI editAreaI)
        {
            countryCallback = country;
            editArea = editAreaI;
        }
        public MasterServices(MasterI masterI, DeleteAreaI deleteAreaI)
        {
            this.masterCallback = masterI;
            this.deleteAreaI = deleteAreaI;
        }
        public MasterServices(CountryI country)
        {
            countryCallback = country;
        }
        public MasterServices(MasterI masterI)
        {
            this.masterCallback = masterI;
        }
        public MasterServices(WardenCreatrI call)
        {
            wardenCallback = call;
        }

        public MasterServices(MasterI master, HostelI hostel)
        {
            this.masterCallback = master;
            this.hostelCallback = hostel;
        }
        public MasterServices(MasterI masterI, BlockI blockI)
        {
            this.masterCallback = masterI;
            this.blockCallback = blockI;
        }
        public MasterServices(MasterI masterI, EditBlockI blockI)
        {
            this.masterCallback = masterI;
            this.editBlockI = blockI;
        }
        public MasterServices(MasterI masterI, DeleteBlockI blockI)
        {
            this.masterCallback = masterI;
            DeleteBlockI = blockI;
        }
        public MasterServices(MasterI master, FloorI floor)
        {
            this.masterCallback = master;
            this.floorCallback = floor;
        }
        public MasterServices(MasterI master, EditFloorI floor)
        {
            this.masterCallback = master;
            this.flooredit = floor;
        }
        public MasterServices(MasterI master, DeleteFloorI floor)
        {
            this.masterCallback = master;
            deleteFloor = floor;
        }
        public MasterServices(MasterI master, DeleteRoomI room)
        {
            this.masterCallback = master;
            deleteRoomI = room;
        }
        public MasterServices(MasterI master, DeleteRoomBedI roombed)
        {
            this.masterCallback = master;
            DeleteRoomBedI = roombed;
        }
        public MasterServices(ServiceCategoryI i)
        {
            categoryCallback = i;
        }

        public MasterServices(FasilityI i)
        {
            fasilityCallback = i;
        }

        public MasterServices(MasterI master_, RoomI room_)
        {
            masterCallback = master_;
            roomCallback = room_;
        }
        public MasterServices(MasterI master, EditRoomI editRoom)
        {
            this.masterCallback = master;
            this.editRoomI = editRoom;
        }
        public MasterServices(MasterI master, EditRoomBedI editRoom)
        {
            this.masterCallback = master;
            this.roomBedI = editRoom;
        }
        public MasterServices(MasterI master, RoomBedI bedI, RoomListI roomListI)
        {
            this.masterCallback = master;
            roomBedCallback = bedI;
            this.roomListI = roomListI;
        }
        public MasterServices(IDisciplinary disciplinarys)
        {
            disciplinary = disciplinarys;
        }
        public async void UpdateDisciplinaryType(UpdateDisciplinaryType updateDisciplinary)
        {
            UpdateDisciplinaryResponse updateDisciplinaryResponse;
            UpdateDisciplinaryErrorResponse updateDisciplinaryErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateDisciplinary);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateDisciplinaryType, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateDisciplinaryResponse = JsonConvert.DeserializeObject<UpdateDisciplinaryResponse>(result);
                    editDisciplinary.UpdateDisciplinaryType(updateDisciplinaryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateDisciplinaryErrorResponse = JsonConvert.DeserializeObject<UpdateDisciplinaryErrorResponse>(result);
                    editDisciplinary.Failer(updateDisciplinaryErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateRoomType(UpdateRoomTypeModel updateRoomTypeModel)
        {
            UpdateRoomTypeResponse updateDisciplinaryResponse;
            UpdateRoomErrorTypeResponse updateDisciplinaryErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateRoomTypeModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateRoomType, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateDisciplinaryResponse = JsonConvert.DeserializeObject<UpdateRoomTypeResponse>(result);
                    EditRoomTypeI.UpdateRoomTypeSuccess(updateDisciplinaryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateDisciplinaryErrorResponse = JsonConvert.DeserializeObject<UpdateRoomErrorTypeResponse>(result);
                    EditRoomTypeI.ServiceFaild(updateDisciplinaryErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateServiceCategory(UpdateServiceCategoryModel updateServiceCategoryModel)
        {
            UpdateServicecategoryResponse updateServicecategoryResponse;
            UpdateServiceCategoryErrorResponse updateServiceCategoryErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateServiceCategoryModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateServicecategory, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateServicecategoryResponse = JsonConvert.DeserializeObject<UpdateServicecategoryResponse>(result);
                    editservicecategory.getallservicecategory(updateServicecategoryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateServiceCategoryErrorResponse = JsonConvert.DeserializeObject<UpdateServiceCategoryErrorResponse>(result);
                    editservicecategory.failer(updateServiceCategoryErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void Updatenewsfeed(UpdateNewsFeed updateNewsFeed)
        {
            UpdateNewsFeedResponse updateNewsFeedResponse;
            UpdateNewsFeederrorresponse updateNewsFeederrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateNewsFeed);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateNotification, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeedResponse = JsonConvert.DeserializeObject<UpdateNewsFeedResponse>(result);
                    editnewsfeeddata.UpdateNewsFeed(updateNewsFeedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeederrorresponse = JsonConvert.DeserializeObject<UpdateNewsFeederrorresponse>(result);
                    editnewsfeeddata.Servicefailed(updateNewsFeederrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateFacility(UpdateFacility updateFacility)
        {
            UpdateFacilityresponse updateFacilityresponse;
            UpdateFacilityerrorresponse updateFacilityerrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateFacility);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateFacility, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateFacilityresponse = JsonConvert.DeserializeObject<UpdateFacilityresponse>(result);
                    editFasilityI.PostFasilitySuccess(updateFacilityresponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateFacilityerrorresponse = JsonConvert.DeserializeObject<UpdateFacilityerrorresponse>(result);
                    editFasilityI.ServiceFaild(updateFacilityerrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void SavewardenAssignment(WardenAssignment wardenAssignment)
        {
            UpdateFacilityresponse updateFacilityresponse;
            UpdateFacilityerrorresponse updateFacilityerrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(wardenAssignment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.Wardenassignment, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateFacilityresponse = JsonConvert.DeserializeObject<UpdateFacilityresponse>(result);
                    iwardenAssignment.SaveWardenassignment(updateFacilityresponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateFacilityerrorresponse = JsonConvert.DeserializeObject<UpdateFacilityerrorresponse>(result);
                    iwardenAssignment.servicefailed(updateFacilityerrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void RoomList()
        {
            UserDialogs.Instance.ShowLoading();
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            var json = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetRoomList);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    json = await response.Content.ReadAsStringAsync();
                    ObservableCollection<RoomListModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomListModel>>(json);
                    await roomListCallback.LoadRoomList(batchData);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await roomListCallback.Failer();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", "No Data Found.", "OK");
                //await roomListCallback.Failer();
            }
        }
        public async void ViewFacility()
        {
            UserDialogs.Instance.ShowLoading();
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            var json = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.FacilityList);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    json = await response.Content.ReadAsStringAsync();
                    ObservableCollection<ViewFacility> batchData = JsonConvert.DeserializeObject<ObservableCollection<ViewFacility>>(json);
                    for(int i=0;i<batchData.Count;i++)
                    {
                        batchData[i].listcount = (i + 1).ToString();
                    }
                    viewFacilityI.LoadFacilityList(batchData);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    viewFacilityI.ServiceFaild("No Facility List");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                viewFacilityI.ServiceFaild("Something went wron please contact from administrator.");
                //await roomListCallback.Failer();
            }
        }
        public async void ViewDisciplinaryType()
        {
            UserDialogs.Instance.ShowLoading();
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            var json = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.DisciplinaryList);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    json = await response.Content.ReadAsStringAsync();
                    ObservableCollection<ViewDisciplinaryType> batchData = JsonConvert.DeserializeObject<ObservableCollection<ViewDisciplinaryType>>(json);
                    for (int i = 0; i < batchData.Count; i++)
                    {
                        batchData[i].listcount = (i+1).ToString();
                    }
                    ViewIDisciplinary.LoadDisciplinaryList(batchData);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    ViewIDisciplinary.ServiceFailed("No Disciplinary List");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                ViewIDisciplinary.ServiceFailed("Something went wron please contact from administrator.");
                //await roomListCallback.Failer();
            }
        }
        public async void RoomListname(string hostelid, string blockid)
        {
            RoomNameResponse roomNameResponse;
            UserDialogs.Instance.ShowLoading();
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("hostelId", hostelid);
            client.DefaultRequestHeaders.Add("blockId", blockid);
            string json;
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllRoom);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    json = await response.Content.ReadAsStringAsync();
                    var jsonresult = json;
                    if (jsonresult.Equals("No Data Found"))
                    {
                        roomNameResponse = JsonConvert.DeserializeObject<RoomNameResponse>(jsonresult);
                        roomListI.NoListFound(roomNameResponse.message);
                    }
                    else
                    {
                        ObservableCollection<RoomNameList> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomNameList>>(json);
                        for (int i = 0; i < batchData.Count; i++)
                        {
                            batchData[i].listcount = (i+1).ToString();
                        }
                        roomListI.LoadRoomList(batchData);
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    roomListI.ServiceFaild("Data Not Found");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                roomListI.ServiceFaild("Data Not Found");
            }
        }
        public async void GetRoomBedList(string hostelid)
        {
            RoomBedResponses roomBedResponse;
            UserDialogs.Instance.ShowLoading();
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("hostelId", hostelid);
            var json = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllRoomBed);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    json = await response.Content.ReadAsStringAsync();
                    if (json.Equals("No Data Found"))
                    {
                        roomBedResponse = JsonConvert.DeserializeObject<RoomBedResponses>(json);
                        roomBed.NoListFound(roomBedResponse.message);
                    }
                    else
                    {
                        ObservableCollection<RoomBedData> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomBedData>>(json);
                        for (int i = 0; i < batchData.Count; i++)
                        {
                            batchData[i].listcount = (i+1).ToString();
                        }
                        roomBed.LoadRoomBedList(batchData);
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    roomBed.Failer("Data Not Found");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                roomBed.Failer("Data Not Found");
                //await roomListCallback.Failer();
            }
        }
        #region CountryAndState
        public async void GetCountryDetails()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            var json = "";

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.Country);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<CountryModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<CountryModel>>(result);

                    await countryCallback.LoadCountry(batchData);
                }
                else
                {
                    await countryCallback.LoadCountryFail();
                }
            }
            catch (Exception ex)
            {
                await countryCallback.LoadCountryFail();
            }
        }
        public async void RequestStateList(CountryModel countryselect)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            byte[] byt = System.Text.Encoding.UTF8.GetBytes(countryselect.id);

            // convert the byte array to a Base64 string

            string idValue = Convert.ToBase64String(byt);

            client.DefaultRequestHeaders.Add("iCode", idValue);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.State);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<StateModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<StateModel>>(result);
                    await countryCallback.LoadStateList(batchData);
                }
                else
                {
                    await countryCallback.LoadStateListFail();
                }
            }
            catch (Exception ex)
            {
                await countryCallback.LoadStateListFail();
            }


        }
        public async void StateListForEditing(string id)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            byte[] byt = System.Text.Encoding.UTF8.GetBytes(id);

            // convert the byte array to a Base64 string

            string idValue = Convert.ToBase64String(byt);

            client.DefaultRequestHeaders.Add("iCode", idValue);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.State);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<StateModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<StateModel>>(result);
                    await countryCallback.LoadStateList(batchData);
                }
                else
                {
                    await countryCallback.LoadStateListFail();
                }
            }
            catch (Exception ex)
            {
                await countryCallback.LoadStateListFail();
            }
        }
        public async void UpdateArea(UpdateAreModel updateAreModel)
        {
            UpdateAreaResponse updateAreaResponse;
            UpdateAreaErrorResponse updateAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateAreModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateArea, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaResponse = JsonConvert.DeserializeObject<UpdateAreaResponse>(result);
                    editArea.UpdateAreaDetailSucess(updateAreaResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaErrorResponse = JsonConvert.DeserializeObject<UpdateAreaErrorResponse>(result);
                    editArea.servicefailed(updateAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteNotification(string id)
        {
            UpdateNewsFeedResponse updateNewsFeedResponse;
            UpdateNewsFeederrorresponse updateNewsFeederrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteNotification, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeedResponse = JsonConvert.DeserializeObject<UpdateNewsFeedResponse>(result);
                    deletenewsfeeddata.Deletenewsfeedlist(updateNewsFeedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeederrorresponse = JsonConvert.DeserializeObject<UpdateNewsFeederrorresponse>(result);
                    deletenewsfeeddata.Servicefailed(updateNewsFeederrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteRoomType(string id)
        {
            UpdateRoomTypeResponse updateNewsFeedResponse;
            UpdateRoomErrorTypeResponse updateNewsFeederrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteRoomType, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeedResponse = JsonConvert.DeserializeObject<UpdateRoomTypeResponse>(result);
                    DeleteRoomTypeI.DeleteRoomTypeSuccess(updateNewsFeedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeederrorresponse = JsonConvert.DeserializeObject<UpdateRoomErrorTypeResponse>(result);
                    DeleteRoomTypeI.ServiceFaild(updateNewsFeederrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteServiceCategory(string id)
        {
            UpdateServicecategoryResponse updateServicecategoryResponse;
            UpdateServiceCategoryErrorResponse updateServiceCategoryErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteServiceCategory, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateServicecategoryResponse = JsonConvert.DeserializeObject<UpdateServicecategoryResponse>(result);
                    deleteservicecategory.Deleteservicecategory(updateServicecategoryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateServiceCategoryErrorResponse = JsonConvert.DeserializeObject<UpdateServiceCategoryErrorResponse>(result);
                    deleteservicecategory.failer(updateServiceCategoryErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteDisciplinaryType(string id)
        {
            UpdateDisciplinaryResponse updateDisciplinaryResponse;
            UpdateDisciplinaryErrorResponse updateDisciplinaryErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteDisciplinaryType, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateDisciplinaryResponse = JsonConvert.DeserializeObject<UpdateDisciplinaryResponse>(result);
                    deleteDisciplinary.DeleteDisciplinaryType(updateDisciplinaryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateDisciplinaryErrorResponse = JsonConvert.DeserializeObject<UpdateDisciplinaryErrorResponse>(result);
                    deleteservicecategory.failer(updateDisciplinaryErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteFacility(string id)
        {
            UpdateFacilityresponse updateFacilityresponse;
            UpdateFacilityerrorresponse updateFacilityerrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteFacility, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateFacilityresponse = JsonConvert.DeserializeObject<UpdateFacilityresponse>(result);
                    deleteFasilityI.PostFasilitySuccess(updateFacilityresponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateFacilityerrorresponse = JsonConvert.DeserializeObject<UpdateFacilityerrorresponse>(result);
                    deleteFasilityI.ServiceFaild(updateFacilityerrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteArea(string areaId)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""areaId"" : """ + areaId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteArea, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    deleteAreaI.DeleteAreaSucess(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    deleteAreaI.servicefailed(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteBlock(string id)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteBlock, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    DeleteBlockI.DeleteBlockSucess(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    DeleteBlockI.ServiceFaild(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateHostel(UpdateHostel updateHostel)
        {
            UpdateHostelResponse updateHostelResponse;
            UpdateHostelErrorResponse updateHostelErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateHostel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateHostel, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateHostelResponse = JsonConvert.DeserializeObject<UpdateHostelResponse>(result);
                    editHostel.PostHostelNameSuccess(updateHostelResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateHostelErrorResponse = JsonConvert.DeserializeObject<UpdateHostelErrorResponse>(result);
                    editHostel.ServiceFaild(updateHostelErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteHostel(string hostelId)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""hostelId"" : """ + hostelId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteHostel, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    deleteHostelI1.DeleteHostelNameSuccess(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    deleteHostelI1.ServiceFaild(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateBlock(UpdateBlock updateBlock)
        {
            UpdateBlockResponse updateBlockResponse;
            UpdateBlockErrorResponse updateBlockErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateBlock);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateBlock, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateBlockResponse = JsonConvert.DeserializeObject<UpdateBlockResponse>(result);
                    editBlockI.PostBlockNameSuccess(updateBlockResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateBlockErrorResponse = JsonConvert.DeserializeObject<UpdateBlockErrorResponse>(result);
                    editBlockI.ServiceFaild(updateBlockErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void Savedisciplinary(DisciplinaryType disciplinaryType)
        {
            DisciplinaryResponse disciplinaryResponse;
            DisciplinaryErrorResponse disciplinaryErrorResponse;
            HttpResponseMessage response;
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(disciplinaryType);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.SaveDisciplinaryType, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    disciplinaryResponse = JsonConvert.DeserializeObject<DisciplinaryResponse>(result);
                    disciplinary.SaveDisciplinaryType(disciplinaryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    disciplinaryErrorResponse = JsonConvert.DeserializeObject<DisciplinaryErrorResponse>(result);
                    await areaCallback.ServiceFaild(disciplinaryErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void RequestAreaList(StateModel stateselect)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            byte[] byt = System.Text.Encoding.UTF8.GetBytes(stateselect.id);

            // convert the byte array to a Base64 string

            string idValue = Convert.ToBase64String(byt);

            client.DefaultRequestHeaders.Add("sCode", idValue);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AreaAvailable);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<AreaModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<AreaModel>>(result);
                    await countryCallback.LoadAreaList(batchData);


                }
                else
                {
                    await countryCallback.LoadAreaListFail();
                }
            }
            catch (Exception ex)
            {
                await countryCallback.LoadAreaListFail();
            }
        }
        public async void AreaListForEditing(string id)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            byte[] byt = System.Text.Encoding.UTF8.GetBytes(id);

            // convert the byte array to a Base64 string

            string idValue = Convert.ToBase64String(byt);

            client.DefaultRequestHeaders.Add("sCode", idValue);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AreaAvailable);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<AreaModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<AreaModel>>(result);
                    await countryCallback.LoadAreaList(batchData);


                }
                else
                {
                    await countryCallback.LoadAreaListFail();
                }
            }
            catch (Exception ex)
            {
                await countryCallback.LoadAreaListFail();
            }
        }
        public async void SaveAreaEntry(SaveAreaModel entryModel)
        {
            HttpResponseMessage response;
            AreaResponse arearesponse;
            AreaErrorResponse areaErrorResponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                //string url = "?newGetAttId=true";
                string json = JsonConvert.SerializeObject(entryModel);
                //string json = @"{""userId"" : """ + App.userid.ToString() + @""",""stateId"" : """ + entryModel.stateId.ToString() + @""",""areaName"" : """ + entryModel.areaName.ToString() + @"""}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    response = await client.PostAsync(ApplicationURL.AreaInsertion, content);

                    if ((int)response.StatusCode == 200)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        arearesponse = JsonConvert.DeserializeObject<AreaResponse>(result);
                        await areaCallback.PostAreaNameSuccess(arearesponse.message);
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        areaErrorResponse = JsonConvert.DeserializeObject<AreaErrorResponse>(result);
                        await areaCallback.ServiceFaild(areaErrorResponse.errors[0].message);
                    }
                }
                catch (Exception ex)
                {
                    await areaCallback.ServiceFaild(ex.ToString());
                }
            }
            catch (InvalidCastException e)
            {
                //await DisplayAlert("", "Data's are not available", "ok");
            }
        }
        public async void SaveHostelEntry(HostelModel entryModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            HostelResponse hostelResponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string json = @"{""hostelName"" : """ + entryModel.hostelName.ToString() + @""",""hostelForGender"" : """ + entryModel.hostelForGender.ToString() + @""",""addressLine1"" : """ + entryModel.addressLine1.ToString() + @""",""zipCode"" : """ + entryModel.zipCode.ToString() + @""",""phone"" : """
                            + entryModel.phone.ToString() + @""",""email"" : """ + entryModel.email.ToString() + @""",""areaId"" : """ + entryModel.areaId.ToString() + @"""}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.HostelInsertion, content);
                string resultHostels = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    hostelResponse = JsonConvert.DeserializeObject<HostelResponse>(resultHostel);
                    await hostelCallback.PostHostelNameSuccess(hostelResponse.message);
                }
                else
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    hostelResponse = JsonConvert.DeserializeObject<HostelResponse>(resultHostel);
                    await hostelCallback.ServiceFaild(hostelResponse.message);
                }
            }
            catch (Exception e)
            {
                await hostelCallback.ServiceFaild(e.ToString());
            }
        }
        #endregion


        public async void SaveBlockEntry(BlockModel entryModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            BlockResponse blockresponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                //string json = JsonConvert.SerializeObject(entryModel);
                string json = @"{""blockName"" : """ + entryModel.name + @""",""hostelId"" : """ + entryModel.hostelId + @""",""areaId"" : """ + entryModel.areaId + @"""}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.BlockInsertion, content);

                if ((int)response.StatusCode == 200)
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    blockresponse = JsonConvert.DeserializeObject<BlockResponse>(resultHostel);
                    await blockCallback.PostBlockNameSuccess(blockresponse.message);
                }
                else
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    blockresponse = JsonConvert.DeserializeObject<BlockResponse>(resultHostel);
                    await blockCallback.ServiceFaild(blockresponse.message);
                }
            }
            catch (Exception e)
            {
                string resultHostel = await response.Content.ReadAsStringAsync();
                blockresponse = JsonConvert.DeserializeObject<BlockResponse>(resultHostel);
                await blockCallback.ServiceFaild(blockresponse.message);
            }
        }
        public async void SaveFloorEntry(FloorModel entryModel)
        {
            FloorResponse floorrResponse;
            FloorErrorResponse floorErrorResponse;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string json = JsonConvert.SerializeObject(entryModel);
                //string json = @"{""floorName"" : """ + entryModel.floorName + @""",""hostelId"" : """ + entryModel.hostelId + @""","",""blocks_id"" : """ + entryModel.blocks_id + @""",""noOfRooms"" : """ + entryModel.noOfRooms + @"""}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.Floornsertion, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    floorrResponse = JsonConvert.DeserializeObject<FloorResponse>(resultHostel);
                    await floorCallback.PostFloorSuccess(floorrResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    floorErrorResponse = JsonConvert.DeserializeObject<FloorErrorResponse>(resultHostel);
                    await floorCallback.ServiceFaild(floorErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await floorCallback.ServiceFaild(e.ToString());
            }
        }
        public async void UpdateFloor(UpdateFloorData updateFloorData)
        {
            UpdateFloorResponse updateFloorResponse;
            UpdateFloorErrorResponse updateFloorErrorResponse;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string json = JsonConvert.SerializeObject(updateFloorData);
                //string json = @"{""floorName"" : """ + entryModel.floorName + @""",""hostelId"" : """ + entryModel.hostelId + @""","",""blocks_id"" : """ + entryModel.blocks_id + @""",""noOfRooms"" : """ + entryModel.noOfRooms + @"""}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.UpdateFloor, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateFloorResponse = JsonConvert.DeserializeObject<UpdateFloorResponse>(resultHostel);
                    flooredit.FloorEditSucess(updateFloorResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateFloorErrorResponse = JsonConvert.DeserializeObject<UpdateFloorErrorResponse>(resultHostel);
                    flooredit.ServiceFaild(updateFloorErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await floorCallback.ServiceFaild(e.ToString());
            }
        }
        public async void DeleteFloor(string id)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""id"" : """ + id + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteFloor, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    deleteFloor.DeleteFloorSucess(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    deleteFloor.ServiceFaild(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void SaveRoomEntry(RoomDataModel entryModel)
        {
            HttpResponseMessage response;
            RoomResponse roomResponse;
            RoomErrorResponse roomErrorResponse;
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                //string roomStatus = "1";
                string json = JsonConvert.SerializeObject(entryModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.RoomInsertion, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    roomResponse = JsonConvert.DeserializeObject<RoomResponse>(resultHostel);
                    await roomCallback.PostRoomSuccess(roomResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    roomErrorResponse = JsonConvert.DeserializeObject<RoomErrorResponse>(resultHostel);
                    await roomCallback.ServiceFaild(roomErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await roomCallback.ServiceFaild(e.ToString());
            }
        }
        public async void UpdateRoom(UpdateRoomModel updateRoomModel)
        {
            HttpResponseMessage response;
            UpdateRoomResponse updateRoomResponse;
            UpdateRoomErrorResponse updateRoomErrorResponse;
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                //string roomStatus = "1";
                string json = JsonConvert.SerializeObject(updateRoomModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.UpdateRoom, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateRoomResponse = JsonConvert.DeserializeObject<UpdateRoomResponse>(resultHostel);
                    editRoomI.EditRoomSucess(updateRoomResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateRoomErrorResponse = JsonConvert.DeserializeObject<UpdateRoomErrorResponse>(resultHostel);
                    editRoomI.ServiceFaild(updateRoomErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", e.ToString(), "OK");
            }
        }
        public async void DeleteRoom(string roomId)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""roomId"" : """ + roomId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteRoom, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    deleteRoomI.DeleteRoomSucess(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    deleteRoomI.ServiceFaild(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteRoomBed(string bedId)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""bedId"" : """ + bedId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteRoomBed, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    DeleteRoomBedI.DeleteRoomBedSucess(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    DeleteRoomBedI.Failer(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void GetAllRomType()
        {

            var client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            FloorResponse floorResponse;
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            try
            {
                response = await client.GetAsync(ApplicationURL.AllRoomType);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<RoomTypeModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomTypeModel>>(result);
                    for (int i = 0; i < batchData.Count; i++)
                    {
                        batchData[i].listcount = i.ToString();
                    }
                    await floorCallback.LoadRoomType(batchData);
                }
                else
                {
                    string result = await response.Content.ReadAsStringAsync();
                    floorResponse = JsonConvert.DeserializeObject<FloorResponse>(result);
                    await floorCallback.ServiceFaild(floorResponse.message);
                }
            }
            catch (Exception ex)
            {
                string result = await response.Content.ReadAsStringAsync();
                floorResponse = JsonConvert.DeserializeObject<FloorResponse>(result);
                await floorCallback.ServiceFaild(floorResponse.message);
            }


        }
        public async void GetAllRomType1()
        {
            RoomTypeResponses roomTypeResponse;

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllRoomType);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result.Equals("No Data Found"))
                    {
                        roomTypeResponse = JsonConvert.DeserializeObject<RoomTypeResponses>(result);
                        roomCallback.NoListFound(roomTypeResponse.message);
                    }
                    else
                    {
                        ObservableCollection<RoomTypeModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomTypeModel>>(result);
                        for(int i=0;i<batchData.Count;i++)
                        {
                            batchData[i].listcount = (i + 1).ToString();
                        }
                        await roomCallback.LoadRoomType(batchData);

                    }
                }
                else
                {
                    await roomCallback.ServiceFaild("No Rooms Available");
                }
            }
            catch (Exception ex)
            {
                await roomCallback.ServiceFaild("No Rooms Available");
            }
        }
        public async void GetAllRomTypeForRoomBed()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllRoomType);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<RoomTypeModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomTypeModel>>(result);
                    await roomBedCallback.LoadRoomTypeList(batchData);
                }
                else
                {
                    await roomCallback.ServiceFaild("No Rooms Available");
                }
            }
            catch (Exception ex)
            {
                await roomCallback.ServiceFaild(ex.ToString());
            }
        }
        public async void GetAllArea()
        {
            AreaModelResponse areaModelResponse;
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllArea);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result.Equals("No Data Found"))
                    {
                        areaModelResponse = JsonConvert.DeserializeObject<AreaModelResponse>(result);
                        masterCallback.NoListFound(areaModelResponse.message);
                    }
                    else
                    {
                        ObservableCollection<AreaModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<AreaModel>>(result);
                        for (int i = 0; i < batchData.Count; i++)
                        {
                            batchData[i].listcount = (i+1).ToString();
                        }
                        await masterCallback.LoadAreaList(batchData);
                    }
                }
                else
                {
                    await masterCallback.ServiceFailed(1);
                }
            }
            catch (Exception ex)
            {
                await masterCallback.ServiceFailed(1);
            }
        }

        public async void GetAllHostel(string areaId)
        {
            HostelModelResponse hostelModelResponse;
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("areaId", areaId.ToString());

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllHostel);

                if ((int)response.StatusCode == 200)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<HostelModel> batchData;

                    if (result.Equals("No Data Found"))
                    {
                        hostelModelResponse = JsonConvert.DeserializeObject<HostelModelResponse>(result);
                        masterCallback.NoListFound(hostelModelResponse.message);
                    }
                    else
                    {
                        batchData = JsonConvert.DeserializeObject<ObservableCollection<HostelModel>>(result);
                        for (int i = 0; i < batchData.Count; i++)
                        {
                            batchData[i].listcount = (i + 1).ToString();
                        }
                        await masterCallback.LoadHostelList(batchData);
                    }
                }
                else
                {
                    await masterCallback.ServiceFailed(2);
                }
            }
            catch (Exception ex)
            {
                await masterCallback.ServiceFailed(2);
            }


        }

        public async void GetAllBlock(string id)
        {
            BlockModelResponse blockModelResponse;
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("hostelId", id);
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllBlock);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result.Equals("No Data Found"))
                    {
                        blockModelResponse = JsonConvert.DeserializeObject<BlockModelResponse>(result);
                        masterCallback.NoListFound(blockModelResponse.message);
                    }
                    else
                    {
                        ObservableCollection<BlockModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<BlockModel>>(result);
                        for (int i = 0; i < batchData.Count; i++)
                        {
                            batchData[i].listcount = (i + 1).ToString();
                        }
                        await masterCallback.LoadBlockList(batchData);
                    }

                }
                else
                {
                    await masterCallback.ServiceFailed(3);
                }
            }
            catch (Exception ex)
            {
                await masterCallback.ServiceFailed(3);
            }

        }

        public async void GetAllBlock(string areaId, string hostelId)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("areaId", areaId);
            client.DefaultRequestHeaders.Add("hostelId", hostelId);
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllBlock);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<BlockModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<BlockModel>>(result);
                    for (int i = 0; i < batchData.Count; i++)
                    {
                        batchData[i].listcount = (i + 1).ToString();
                    }
                    await masterCallback.LoadBlockList(batchData);
                }
                else
                {
                    await masterCallback.ServiceFailed(3);
                }
            }
            catch (Exception ex)
            {
                await masterCallback.ServiceFailed(3);
            }

        }

        public async void GetAllFloor(string hostelId)
        {
            FloorDataResponse floorDataResponse;
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            client.DefaultRequestHeaders.Add("hostelId", hostelId);
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllFloor);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result.Equals("No Data Found"))
                    {
                        floorDataResponse = JsonConvert.DeserializeObject<FloorDataResponse>(result);
                        masterCallback.NoListFound(floorDataResponse.message);
                    }
                    else
                    {
                        ObservableCollection<FloorData> batchData = JsonConvert.DeserializeObject<ObservableCollection<FloorData>>(result);
                        for (int i = 0; i < batchData.Count; i++)
                        {
                            batchData[i].listcount = (i + 1).ToString();
                        }
                        await masterCallback.LoadFloorList(batchData);
                    }
                }
                else
                {
                    await masterCallback.ServiceFailed(4);
                }
            }
            catch (Exception ex)
            {
                await masterCallback.ServiceFailed(4);
            }

        }
        public async void SaveServiceCategory(ServiceCategoryModel model)
        {
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                ServicecategoryResponse servicecategoryResponse;
                ServiceCategoryErrorResponse serviceCategoryErrorResponse;
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string json = JsonConvert.SerializeObject(model);
                //string json = @"{""name"" : """ + model.name + @"""}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.ServiceCategoryInsertion, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    servicecategoryResponse = JsonConvert.DeserializeObject<ServicecategoryResponse>(resultHostel);
                    await categoryCallback.PostServiceCategorySuccess(servicecategoryResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    serviceCategoryErrorResponse = JsonConvert.DeserializeObject<ServiceCategoryErrorResponse>(resultHostel);
                    await categoryCallback.ServiceFaild(serviceCategoryErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await categoryCallback.ServiceFaild(e.ToString());
            }
        }

        public async void SaveFasility(FasilityModel model)
        {
            try
            {
                var client = new HttpClient();
                HttpResponseMessage response;
                Facilityresponse facilityresponse;
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                //""phone"" : """ + entryModel.phone.ToString() + @""",""email"" : """ + entryModel.email.ToString() + @"""
                string json = @"{""userId"" : """ + Constants.UserId + @""",""name"" : """ + model.name + @"""}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.FasilityInsertion, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    facilityresponse = JsonConvert.DeserializeObject<Facilityresponse>(resultHostel);
                    await fasilityCallback.PostFasilitySuccess(facilityresponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    await fasilityCallback.ServiceFaild(resultHostel.ToString());
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await fasilityCallback.ServiceFaild(e.ToString());
            }
        }

        #region RoomBed
        public async void GetAllArea1()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("sCode", "MQ==");
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllArea);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<AreaModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<AreaModel>>(result);
                    await roomBedCallback.LoadAreaList(batchData);


                }
                else
                {
                    await roomBedCallback.Failer(1);
                }
            }
            catch (Exception ex)
            {
                await roomBedCallback.Failer(1);
            }


        }

        public async void GetAllHostel1(string areaid)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("areaId", areaid.ToString());

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllHostel);

                if ((int)response.StatusCode == 200)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<HostelModel> batchData;

                    if (result.Contains("No Data Found"))
                    {
                        batchData = new ObservableCollection<HostelModel>();
                        await roomBedCallback.LoadHostelList(batchData);
                    }
                    else
                    {
                        batchData = JsonConvert.DeserializeObject<ObservableCollection<HostelModel>>(result);
                        await roomBedCallback.LoadHostelList(batchData);
                    }




                }
                else
                {
                    await roomBedCallback.Failer(2);
                }
            }
            catch (Exception ex)
            {
                await roomBedCallback.Failer(2);
            }


        }

        public async void SaveRoomBed(string hostelId, string bedNo, string userId, string hostelRoomId)
        {
            HttpResponseMessage response;
            RoomResponse roomResponse;
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                string json = @"{""hostelId"" : """ + hostelId + @""",""bedNo"" : """ + bedNo + @""",""userId"":""" + userId + @""",""hostelRoomId"":""" + hostelRoomId + @"""}";


                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.RoomBedInsertion, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    roomResponse = JsonConvert.DeserializeObject<RoomResponse>(resultHostel);
                    await roomBedCallback.SaveRoomBedSuccess(roomResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await roomBedCallback.Failer(3);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await roomBedCallback.Failer(3);
            }
        }
        public async void UpdateRoomBed(UpdateRoomBed updateRoomBed)
        {
            HttpResponseMessage response;
            UpdateRoomBedResponse updateRoomBedResponse;
            UpdateRoomBedErrorResponse updateRoomBedErrorResponse;
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateRoomBed);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateRoomBed, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateRoomBedResponse = JsonConvert.DeserializeObject<UpdateRoomBedResponse>(resultHostel);
                    roomBedI.EditRoomBedSucess(updateRoomBedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateRoomBedErrorResponse = JsonConvert.DeserializeObject<UpdateRoomBedErrorResponse>(resultHostel);
                    roomBedI.Failer(updateRoomBedErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", e.ToString(), "OK");
            }
        }

        #endregion


        #region WardenCreatioon
        public async void GetAllRole()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);


            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetAllRole);

                if ((int)response.StatusCode == 200)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<RoleModel> batchData;

                    if (result.Contains("No Data Found"))
                    {
                        batchData = new ObservableCollection<RoleModel>();
                        await wardenCallback.GetAllRole(batchData);
                    }
                    else
                    {
                        batchData = JsonConvert.DeserializeObject<ObservableCollection<RoleModel>>(result);
                        await wardenCallback.GetAllRole(batchData);
                    }




                }
                else
                {
                    await wardenCallback.ServiceFaild();
                }
            }
            catch (Exception ex)
            {
                await wardenCallback.ServiceFaild();
            }
        }
        public async void SaveWarden(WardenModel model)
        {
            try
            {
                var client = new HttpClient();
                HttpResponseMessage response;
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                WardenResponse wardenResponse;
                // string json = @"{""hostelId"" : """ + hostelId + @""",""bedNo"" : """ + bedNo + @"""}";
                model.lastName = "";
                model.permanent_address_line_2 = "";
                //model.isWarden = "1";
                model.dateOfBirth = "23/01/1994";
                model.dateOfJoining = "23/01/1994";


                string json = JsonConvert.SerializeObject(model);


                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApplicationURL.SaveWarden, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    wardenResponse = JsonConvert.DeserializeObject<WardenResponse>(resultHostel);
                    await wardenCallback.SaveWarden(wardenResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await wardenCallback.ServiceFaild();
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await wardenCallback.ServiceFaild();
            }
        }

        #endregion
    }
}
