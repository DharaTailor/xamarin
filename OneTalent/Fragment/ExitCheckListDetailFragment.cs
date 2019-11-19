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
    public class ExitCheckListDetailFragment : Fragment
    {
        TextView StatusTextNotStarted;
        TextView StatusTextInProgress;
        TextView StatusTextCompleted;
        TextView ActivityNameText;
        TextView DescriptionText;
        TextView DomainText;
        TextView AssignedText;
        TextView LastUpdatedOnText;
        TextView RemarkDomainNameOneText;
        TextView RemarkDomainNameTwoText;
        TextView ExitCheckListDetailTextview;
        ImageView ProfileImage;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.ExitCheckListDetailViewFragment, container, false);
            UIReference(v);
            SetToolbar();
            return v;
        }

        private void SetToolbar()
        {
            ExitCheckListDetailTextview.Text = Message.ExitCheckListDetail;
            ProfileImage.Visibility = ViewStates.Invisible;
        }

        private void UIReference(View v)
        {
            ExitCheckListDetailTextview = v.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
            ProfileImage = v.FindViewById<ImageView>(Resource.Id.roundProfileImage);
            StatusTextNotStarted = v.FindViewById<TextView>(Resource.Id.NotStartedStatusTextView);
            StatusTextInProgress = v.FindViewById<TextView>(Resource.Id.InProgressStatusTextView);
            StatusTextCompleted = v.FindViewById<TextView>(Resource.Id.CompletedStatusTextView);
            ActivityNameText = v.FindViewById<TextView>(Resource.Id.ActivityNameTextView);
            DescriptionText = v.FindViewById<TextView>(Resource.Id.DescriptionTextView);
            DomainText = v.FindViewById<TextView>(Resource.Id.DomainTextView);
            AssignedText = v.FindViewById<TextView>(Resource.Id.AssignedTextView);
            LastUpdatedOnText = v.FindViewById<TextView>(Resource.Id.lastUpdatedOnTextView);
            RemarkDomainNameOneText = v.FindViewById<TextView>(Resource.Id.remark1TextView);
            RemarkDomainNameTwoText = v.FindViewById<TextView>(Resource.Id.remark2TextView);
        }
    }
}