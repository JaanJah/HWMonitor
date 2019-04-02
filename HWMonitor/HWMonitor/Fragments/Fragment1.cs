using Android.OS;
using Android.Views;
using Android.Widget;
namespace HWMonitor.Fragments
{
    public class Fragment1 : Android.Support.V4.App.Fragment
    {
        public GetHardwareInfo HWInfo { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HWInfo = new GetHardwareInfo();
            HWInfo.GetDeviceInfo();

        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }

        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.fragment1, null);
            SetDeviceInfo(view);
            return view;
        }

        private void SetDeviceInfo(View view)
        {
            view.FindViewById<TextView>(Resource.Id.deviceModel).Text = HWInfo.DeviceModel;
            view.FindViewById<TextView>(Resource.Id.deviceManufacturer).Text = HWInfo.DeviceManufacturer;
            view.FindViewById<TextView>(Resource.Id.deviceName).Text = HWInfo.DeviceName;
            view.FindViewById<TextView>(Resource.Id.deviceVersion).Text = HWInfo.DeviceVersion;
            view.FindViewById<TextView>(Resource.Id.devicePlatform).Text = HWInfo.DevicePlatform.ToString();
            view.FindViewById<TextView>(Resource.Id.deviceIdiom).Text = HWInfo.DeviceIdiom.ToString();
            view.FindViewById<TextView>(Resource.Id.deviceType).Text = HWInfo.DeviceType.ToString();
        }

    }
}