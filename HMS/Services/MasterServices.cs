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
        HostelI hostelCallback;
        MasterI masterCallback;
        BlockI blockCallback;
        ServiceCategoryI categoryCallback;
        FasilityI fasilityCallback;
        FloorI floorCallback;
        RoomI roomCallback;
        RoomBedI roomBedCallback;
        RoomListI roomListCallback;
        WardenCreatrI wardenCallback;
        IDisciplinary disciplinary;
        public MasterServices(RoomListI callback)
        {
            roomListCallback = callback;
        }

        public MasterServices(CountryI countryI, AreaI areaI)
        {
            this.countryCallback = countryI;
            this.areaCallback = areaI;
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

        public MasterServices(MasterI master, FloorI floor)
        {
            this.masterCallback = master;
            this.floorCallback = floor;
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

        public MasterServices(RoomBedI bedI)
        {
            roomBedCallback = bedI;
        }
        public MasterServices(IDisciplinary disciplinarys)
        {
            disciplinary = disciplinarys;
        }
        public async void RoomList()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            var json = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetRoomList);

                if ((int)response.StatusCode == 200)
                {
                    json = await response.Content.ReadAsStringAsync();
                    ObservableCollection<RoomListModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomListModel>>(json);
                    await roomListCallback.LoadRoomList(batchData);
                }
                else
                {
                    await roomListCallback.Failer();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", "No Data Found.", "OK");
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
                    floorrResponse = JsonConvert.DeserializeObject<FloorResponse>(resultHostel);
                    await floorCallback.ServiceFaild(floorrResponse.message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await floorCallback.ServiceFaild(e.ToString());
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

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllRoomType);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<RoomTypeModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<RoomTypeModel>>(result);
                    await roomCallback.LoadRoomType(batchData);


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

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllArea);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<AreaModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<AreaModel>>(result);
                    await masterCallback.LoadAreaList(batchData);


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
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("areaId",areaId.ToString());

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
                        await masterCallback.LoadHostelList(batchData);
                    }
                    else
                    {
                        batchData = JsonConvert.DeserializeObject<ObservableCollection<HostelModel>>(result);
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

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);
            client.DefaultRequestHeaders.Add("hostelId", id);
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllBlock);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    ObservableCollection<BlockModel> batchData = JsonConvert.DeserializeObject<ObservableCollection<BlockModel>>(result);
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

            var client = new HttpClient();
            client.BaseAddress = new Uri(ApplicationURL.BaseURL);

            client.DefaultRequestHeaders.Add("hostelId", hostelId);
            try
            {
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.AllFloor);

                if ((int)response.StatusCode == 200)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    ObservableCollection<FloorData> batchData = JsonConvert.DeserializeObject<ObservableCollection<FloorData>>(result);
                    await masterCallback.LoadFloorList(batchData);
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

        public async void SaveRoomBed(string hostelId, string bedNo)
        {
            HttpResponseMessage response;
            RoomResponse roomResponse;
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                string json = @"{""hostelId"" : """ + hostelId + @""",""bedNo"" : """ + bedNo + @"""}";


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
                model.isWarden = "1";
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
