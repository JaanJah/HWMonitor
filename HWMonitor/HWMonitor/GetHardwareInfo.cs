using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using Xamarin.Essentials;
using Android.Util;

namespace HWMonitor
{
    public class GetHardwareInfo
    {
        public string DeviceModel { get; set; }
        public string DeviceManufacturer { get; set; }
        public string DeviceName { get; set; }
        public string DeviceVersion { get; set; }
        public DevicePlatform DevicePlatform { get; set; }
        public DeviceIdiom DeviceIdiom { get; set; }
        public DeviceType DeviceType { get; set; }

        public void GetDeviceInfo()
        {
            // Device Model
            DeviceModel = DeviceInfo.Model;

            // Manufacturer
            DeviceManufacturer = DeviceInfo.Manufacturer;

            // Device Name
            DeviceName = DeviceInfo.Name;

            // Operating System Version Number
            DeviceVersion = DeviceInfo.VersionString;

            // Platform
            DevicePlatform = DeviceInfo.Platform;

            // Idiom
            DeviceIdiom = DeviceInfo.Idiom;

            // Device Type
            DeviceType = DeviceInfo.DeviceType;
        }
    }
}