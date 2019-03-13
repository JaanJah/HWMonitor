﻿using System;
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
    public class Fragment3 : Android.Support.V4.App.Fragment
    {
        public GetHardwareInfo HWInfo { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HWInfo = new GetHardwareInfo();
            HWInfo.GetDisplayInfo();
        }

        public static Fragment3 NewInstance()
        {
            var frag3 = new Fragment3 { Arguments = new Bundle() };
            return frag3;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment3, null);
            view.FindViewById<TextView>(Resource.Id.displayOrientation).Text = HWInfo.DisplayOrientation.ToString();
            view.FindViewById<TextView>(Resource.Id.displayRotation).Text = HWInfo.DisplayRotation.ToString();
            view.FindViewById<TextView>(Resource.Id.displayWidth).Text = HWInfo.DisplayWidth.ToString();
            view.FindViewById<TextView>(Resource.Id.displayHeight).Text = HWInfo.DisplayHeight.ToString();
            view.FindViewById<TextView>(Resource.Id.displayDensity).Text = HWInfo.DisplayDensity.ToString();
            return view;
        }
    }
}