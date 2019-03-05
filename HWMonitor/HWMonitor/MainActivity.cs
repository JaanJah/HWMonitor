using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Xamarin.Essentials;
using System;

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
            SupportActionBar.Title = "Hardware Monitor";
            //ActionBar.SetHomeAsUpIndicator(Resource.Drawable.settingsBtn);

            //Initialize Xamarin Essentials
            Platform.Init(this, savedInstanceState);

            ///
            /// THIS SECTION IS FOR DEBUG
            ///
            //Check GetHardwareInfo.cs for all properties.
            HWInfo = new GetHardwareInfo();
            
            //Device info
            HWInfo.GetDeviceInfo();
            var text = HWInfo.DeviceModel;

            //Battery info
            HWInfo.GetBatteryInfo();
            //They should be global variables because otherwise they wont update
            var text2 = HWInfo.BatteryChargeLevel;
            var text3 = HWInfo.BatterySource;
            var text4 = HWInfo.BatteryState;

            //Display info
            HWInfo.GetDisplayInfo();
            var text5 = HWInfo.DisplayInfo;
            var text6 = HWInfo.DisplayOrientation;
            //You can also call 2 parameters for every property of DisplayInfo
            //We need to decide if we are going to use DisplayInfo for each parameter
            //Or if we are going to use separately set parameters
            var text7 = HWInfo.DisplayInfo.Orientation;

            ActivityManager.MemoryInfo mem = new ActivityManager.MemoryInfo();
            var tex2t = mem.AvailMem;
            var tx3t = mem.TotalMem;
            var lowmem = mem.LowMemory;
            ///
            /// END OF DEBUG SECTION
            ///

            //Called when BatteryInfo is changed
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            //Called when screen metrics are changed
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
        }

        public void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            HWInfo.GetDisplayInfo();
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