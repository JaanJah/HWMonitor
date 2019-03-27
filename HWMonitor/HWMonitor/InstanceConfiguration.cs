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

namespace HWMonitor
{
    public static class InstanceConfiguration
    {
        public static int LastSelectedTab { get; set; } = Resource.Id.menu_device;
    }
}