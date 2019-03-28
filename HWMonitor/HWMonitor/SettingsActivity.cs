using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace HWMonitor
{
    [Activity(Label = "Settings", Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settingsLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }
        }
    }
}