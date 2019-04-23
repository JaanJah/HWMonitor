using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using HWMonitor;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using System.Threading.Tasks;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true,
    NoHistory = true, Icon = "@drawable/icon",
    ConfigurationChanges = ConfigChanges.Locale | ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class SplashActivity : AppCompatActivity
{
    //TODO: Drawable for all screen densities
    //TODO: Enable crash reports
    //TODO: Add options in settings. (Fahrenheit and Celsius converting)
    //TODO: Add temperature.
    static readonly string TAG = "X:" + typeof(SplashActivity).Name;


    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);
        AppCenter.Start("f7ae5016-aa19-4264-8a45-7817bcf7d0e6", typeof(Analytics), typeof(Crashes), typeof(Distribute));
        Distribute.SetEnabledAsync(true);
        //Get locale
        var lang = Resources.Configuration.Locale;
    }

    // Launches the startup task
    protected override void OnResume()
    {
        base.OnResume();
        Task startupWork = new Task(() => { SimulateStartup(); });
        startupWork.Start();
    }

    // Simulates background work that happens behind the splash screen
    async void SimulateStartup()
    {
        StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
}