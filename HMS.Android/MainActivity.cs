using Acr.UserDialogs;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Plugin.CurrentActivity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.Droid
{
    [Activity(Label = "HMS", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            UserDialogs.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                LoadApplication(new App());
                switch (Device.Idiom)
                {
                    case TargetIdiom.Phone:
                        RequestedOrientation = ScreenOrientation.Portrait;
                        break;
                    case TargetIdiom.Tablet:
                        RequestedOrientation = ScreenOrientation.Portrait;
                        break;
                }
                RequestPermissionsAsync();
            }
            else
                Toast.MakeText(this, "Please Check Your Internet Connection", ToastLength.Long);
        }
        protected override void OnResume()
        {
            base.OnResume();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var profiles = Connectivity.ConnectionProfiles;
            if (profiles.Contains(ConnectionProfile.WiFi) || profiles.Contains(ConnectionProfile.Cellular))
            {
                LoadApplication(new App());
                switch (Device.Idiom)
                {
                    case TargetIdiom.Phone:
                        RequestedOrientation = ScreenOrientation.Portrait;
                        break;
                    case TargetIdiom.Tablet:
                        RequestedOrientation = ScreenOrientation.Portrait;
                        break;
                }
                RequestPermissionsAsync();
            }
        }
        async Task RequestPermissionsAsync()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return;
            }

            await GetPermissionAsync();
        }

        async Task GetPermissionAsync()
        {
            //Check to see if any permission in our group is available, if one, then all are
            const string permission = Manifest.Permission.WriteExternalStorage;
            const string Readpermission = Manifest.Permission.ReadExternalStorage;
            const string Camerapermission = Manifest.Permission.Camera;

            if (CheckSelfPermission(permission) == (int)Permission.Granted && CheckSelfPermission(Readpermission) == (int)Permission.Granted)
            {
                ////await GetLocationAsync();
                return;
            }

            //need to request permission
            if (ShouldShowRequestPermissionRationale(permission))
            {
                //Explain to the user why we need to read the contacts

                return;
            }
            //Finally request permissions with the list of permissions and Id
            RequestPermissions(PermissionsLocation, RequestLocationId);
        }

        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            //Permission granted

                        }
                        else
                        {
                            //Permission Denied :(
                            //Disabling location functionality

                        }
                    }
                    break;
            }
        }


        readonly string[] PermissionsLocation =
       {
             Manifest.Permission.WriteExternalStorage,
             Manifest.Permission.ReadExternalStorage,
             Manifest.Permission.Camera
        };

        const int RequestLocationId = 0;
    }
}