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
        /// <summary>
        /// Device Info
        /// </summary>
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

        /// <summary>
        /// Battery info
        /// </summary>
        public double BatteryChargeLevel { get; set; }
        public BatteryState BatteryState { get; set; }
        public BatteryPowerSource BatterySource { get; set; }

        public void GetBatteryInfo()
        {
            BatteryChargeLevel = Battery.ChargeLevel*100; // Returns battery charge level in percents.

            BatteryState = Battery.State;

            switch (BatteryState)
            {
                case BatteryState.Charging:
                    // Currently charging
                    break;
                case BatteryState.Full:
                    // Battery is full
                    break;
                case BatteryState.Discharging:
                case BatteryState.NotCharging:
                    // Currently discharging battery or not being charged
                    break;
                case BatteryState.NotPresent:
                // Battery doesn't exist in device (desktop computer)
                case BatteryState.Unknown:
                    // Unable to detect battery state
                    break;
            }

            BatterySource = Battery.PowerSource;

            switch (BatterySource)
            {
                case BatteryPowerSource.Battery:
                    // Being powered by the battery
                    break;
                case BatteryPowerSource.AC:
                    // Being powered by A/C unit
                    break;
                case BatteryPowerSource.Usb:
                    // Being powered by USB cable
                    break;
                case BatteryPowerSource.Wireless:
                    // Powered via wireless charging
                    break;
                case BatteryPowerSource.Unknown:
                    // Unable to detect power source
                    break;
            }
        }

        /// <summary>
        /// Display info
        /// </summary>
        private DisplayInfo DisplayInfo { get; set; }
        public DisplayOrientation DisplayOrientation { get; set; }
        public DisplayRotation DisplayRotation { get; set; }
        public double DisplayWidth { get; set; }
        public double DisplayHeight { get; set; }
        public double DisplayDensity { get; set; }
  
        public void GetDisplayInfo()
        {
            // Get Metrics
            DisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            DisplayOrientation = DisplayInfo.Orientation;

            // Rotation (0, 90, 180, 270)
            DisplayRotation = DisplayInfo.Rotation;

            // Width (in pixels)
            DisplayWidth = DisplayInfo.Width;

            // Height (in pixels)
            DisplayHeight = DisplayInfo.Height;

            // Screen density
            DisplayDensity = DisplayInfo.Density;
        }

    }
}