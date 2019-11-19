using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace OneTalent
{
    [Activity(Label = "DashBoardActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class DashBoardActivity : AppCompatActivity
    {
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dashboardActivity);

            UIReferance();
            UIClick();
            LoadFragment(new DashboardFragment());
        }

        private void UIReferance()
        {
            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigationView);
            BottomNavigationHelper.DisableShiftMode(bottomNavigation);
        }

        private void UIClick()
        {
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.dashboard:
                    LoadFragment(new DashboardFragment());
                    break;
                case Resource.Id.request:
                    LoadFragment(new ApplyFragment());
                    break;
                case Resource.Id.approval:
                    LoadFragment(new NullFragment());
                    break;
                case Resource.Id.team:
                    LoadFragment(new NullFragment());
                    break;
            }
        }

        private void LoadFragment(Android.Support.V4.App.Fragment fragment)
        {
            Android.Support.V4.App.FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frameLayout, fragment).Commit();
        }
    }
}