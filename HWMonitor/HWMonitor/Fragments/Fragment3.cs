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
using Xamarin.Essentials;

namespace HWMonitor.Fragments
{
    public class Fragment3 : Android.Support.V4.App.Fragment
    {
        public GetHardwareInfo HWInfo { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HWInfo = new GetHardwareInfo();
            HWInfo.GetDisplayInfo();
            //Called when screen metrics are changed
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
        }

        public static Fragment3 NewInstance()
        {
            var frag3 = new Fragment3 { Arguments = new Bundle() };
            return frag3;
        }

        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.fragment3, null);
            SetDisplayInfo(view);
            return view;
        }

        public void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            HWInfo.GetDisplayInfo();
            SetDisplayInfo(view);
        }

        private void SetDisplayInfo(View view)
        {
            var rotation = HWInfo.DisplayRotation.ToString().Remove(0, 8) + "°";
            view.FindViewById<TextView>(Resource.Id.displayOrientation).Text = HWInfo.DisplayOrientation.ToString();
            view.FindViewById<TextView>(Resource.Id.displayRotation).Text = rotation;
            view.FindViewById<TextView>(Resource.Id.displayWidth).Text = HWInfo.DisplayWidth.ToString();
            view.FindViewById<TextView>(Resource.Id.displayHeight).Text = HWInfo.DisplayHeight.ToString();
            view.FindViewById<TextView>(Resource.Id.displayDensity).Text = HWInfo.DisplayDensity.ToString();
        }
    }
}