using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using HWMonitor;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using System.Threading.Tasks;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
public class SplashActivity : AppCompatActivity
{
    static readonly string TAG = "X:" + typeof(SplashActivity).Name;

    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);
        AppCenter.Start("f7ae5016-aa19-4264-8a45-7817bcf7d0e6", typeof(Analytics), typeof(Crashes), typeof(Distribute));
        Distribute.SetEnabledAsync(true);
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