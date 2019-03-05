using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Xamarin.Essentials;

namespace HWMonitor
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public GetHardwareInfo HWInfo { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Hardware monitor";
            //ActionBar.SetHomeAsUpIndicator(Resource.Drawable.settingsBtn);

            //Initialize Xamarin Essentials
            Platform.Init(this, savedInstanceState);

            ///
            /// THIS SECTION IS FOR DEBUG
            ///
            HWInfo = new GetHardwareInfo();
            
            //Device info
            HWInfo.GetDeviceInfo();
            var text = HWInfo.DeviceModel;

            //Battery info
            HWInfo.GetBatteryInfo();
            var text2 = HWInfo.BatteryChargeLevel;
            var text3 = HWInfo.BatterySource;
            var text4 = HWInfo.BatteryState;

            ///
            /// END OF DEBUG SECTION
            ///


            //Called when BatteryInfo is changed
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        public void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            HWInfo.GetBatteryInfo();
        }

        //Ask for permission to allow Xamarin Essentials
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}