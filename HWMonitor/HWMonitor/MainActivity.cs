﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using HWMonitor.Fragments;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Essentials;
using Android.Content;
using Microsoft.AppCenter.Distribute;

namespace HWMonitor
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AppCenter.Start("f7ae5016-aa19-4264-8a45-7817bcf7d0e6", typeof(Analytics), typeof(Crashes), typeof(Distribute));
            Distribute.SetEnabledAsync(true);
            SetContentView(Resource.Layout.activity_main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            //Initialize Xamarin Essentials
            Platform.Init(this, bundle);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            // Load the first fragment on creation
            LoadFragment(InstanceConfiguration.LastSelectedTab);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            var selectedTab = e.Item.ItemId;
            InstanceConfiguration.LastSelectedTab = selectedTab;
            LoadFragment(selectedTab);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_settings:
                    var settingsActivity = new Intent(this, typeof(SettingsActivity));
                    StartActivity(settingsActivity);
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_device:
                    fragment = Fragment1.NewInstance();
                    break;
                case Resource.Id.menu_battery:
                    fragment = Fragment2.NewInstance();
                    break;
                case Resource.Id.menu_display:
                    fragment = Fragment3.NewInstance();
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }
    }
}