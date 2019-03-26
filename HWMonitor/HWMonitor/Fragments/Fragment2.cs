using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

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
        }

        public static Fragment2 NewInstance()
        {
            var frag2 = new Fragment2 { Arguments = new Bundle() };
            return frag2;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment2, null);
            view.FindViewById<TextView>(Resource.Id.batteryChargeLevel).Text = HWInfo.BatteryChargeLevel.ToString() + "%";
            view.FindViewById<TextView>(Resource.Id.batteryState).Text = HWInfo.BatteryState.ToString();
            view.FindViewById<TextView>(Resource.Id.batterySource).Text = HWInfo.BatterySource.ToString();
            return view;
        }
    }
}