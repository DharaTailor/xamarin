using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using SharedCode;
using Utility;

namespace OneTalent
{
    public class NullFragment : Fragment
    {
        ImageView backImage;
        TextView dashBoardTextView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.NullFragment, container, false);
            backImage = v.FindViewById<ImageView>(Resource.Id.backButton);
            backImage.Visibility = ViewStates.Gone;
            dashBoardTextView = v.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
            dashBoardTextView.Text = "";
            return v;
        }
       
    }
}