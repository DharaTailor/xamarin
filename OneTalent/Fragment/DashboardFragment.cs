using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace OneTalent
{
    public class DashboardFragment : Fragment
    {
        ImageView backImage;
        TextView dashBoardTextView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.homeFragment, container, false);
            var toolbar = v.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.resignationStatusToolbar);
            backImage = v.FindViewById<ImageView>(Resource.Id.backButton);
            backImage.Visibility = ViewStates.Gone;
            dashBoardTextView = v.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
            dashBoardTextView.Text = Message.DashBoard;
            return v;
        }
    }
}