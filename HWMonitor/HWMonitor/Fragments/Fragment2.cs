using Android.OS;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace HWMonitor.Fragments
{
    public class Fragment2 : Android.Support.V4.App.Fragment
    {
        public GetHardwareInfo HWInfo { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HWInfo = new GetHardwareInfo();
            HWInfo.GetBatteryInfo();

            //Called when BatteryInfo is changed
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        public static Fragment2 NewInstance()
        {
            var frag2 = new Fragment2 { Arguments = new Bundle() };
            return frag2;
        }

        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.fragment2, null);
            SetBatteryInfo(view);
            return view;
        }

        public void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            HWInfo.GetBatteryInfo();
            SetBatteryInfo(view);
        }

        private void SetBatteryInfo(View view)
        {
            view.FindViewById<TextView>(Resource.Id.batteryChargeLevel).Text = HWInfo.BatteryChargeLevel.ToString() + "%";
            view.FindViewById<TextView>(Resource.Id.batteryState).Text = HWInfo.BatteryState.ToString();
            view.FindViewById<TextView>(Resource.Id.batterySource).Text = HWInfo.BatterySource.ToString();
        }
    }
}