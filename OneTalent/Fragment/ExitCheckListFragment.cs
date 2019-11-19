using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using SharedCode;
using Utility;

namespace OneTalent
{
    public class ExitCheckListFragment : Fragment
    {
        Button FeedBackButton;
        RecyclerView ExitCheckListRecyclerView;
        ExitCheckListAdapter exitCheckListAdapter;
        FeedBackRequestModel feedBackRequestModel;
        TextView ExitCheckListTextView;
        ExitCheckListViewModel exitCheckListViewModel;
        List<ExitCheckListDetailModel> exitCheckListDetails;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            var action = CallApi();
        }

        private async Task CallApi()
        {
            exitCheckListViewModel = new ExitCheckListViewModel();
            exitCheckListDetails = new List<ExitCheckListDetailModel>();
            ProgressIndicator.Show(Context);
            exitCheckListDetails = await exitCheckListViewModel.GetExitCheckListAsync();
            if(exitCheckListDetails!=null && exitCheckListDetails.Count>0)
            {
                ExitCheckListTextView.Visibility = ViewStates.Gone;
                ExitCheckListRecyclerView.Visibility = ViewStates.Visible;
                ExitCheckListRecyclerView.SetLayoutManager(new LinearLayoutManager(Context));
                exitCheckListAdapter = new ExitCheckListAdapter(exitCheckListDetails);
                ExitCheckListRecyclerView.SetAdapter(exitCheckListAdapter);
                exitCheckListAdapter.NotifyDataSetChanged();
                exitCheckListAdapter.ItemClick += ExitCheckListAdapter_ItemClick;
            }
            else
            {
                ExitCheckListTextView.Text = Message.NotApprovedByHR;
                FeedBackButton.Visibility = ViewStates.Visible;
                ExitCheckListRecyclerView.Visibility = ViewStates.Gone;
            }
        }

        private void ExitCheckListAdapter_ItemClick(object sender, ExitCheckListAdapterClick e)
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.ExitCheckListFragment, container, false);
            UIReference(view);
            UIClick();
            SetToolbar();
            return view;
        }

        private void SetToolbar()
        {
            ExitCheckListTextView.Text = Message.ExitCheckList;
        }

        private void UIReference(View view)
        {
            FeedBackButton = view.FindViewById<Button>(Resource.Id.feedbackButton);
            ExitCheckListRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.exitCheckListRecyclerView);
            ExitCheckListTextView = view.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
        }

        private void UIClick()
        {
            FeedBackButton.Click += FeedBackButton_Click;
        }

        private void FeedBackButton_Click(object sender, EventArgs e)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.FeedbackFormFragment, null);
            Android.App.AlertDialog alertDialog = new Android.App.AlertDialog.Builder(Context).Create();
            alertDialog.SetView(view);
            EditText editTextFeedback;
            Button buttonCancelFeedback;
            Button buttonSubmitFeedback;
            editTextFeedback = view.FindViewById<EditText>(Resource.Id.feedbackEditText);
            buttonCancelFeedback = view.FindViewById<Button>(Resource.Id.buttonCancelFeedback);
            buttonSubmitFeedback = view.FindViewById<Button>(Resource.Id.buttonSubmitFeedback);
            buttonCancelFeedback.Click += delegate
            {
                alertDialog.Dismiss();
            };
            buttonSubmitFeedback.Click += delegate
            {
                feedBackRequestModel = new FeedBackRequestModel
                {
                    feedback = editTextFeedback.Text
                };
                var result = ModelValidator.Validate(feedBackRequestModel);
                if(result != null && !result.Result)
                {
                    Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(Context);
                    builder.SetMessage(result.Message.ToString());
                    builder.SetPositiveButton("OK", (s, a) =>
                    {
                        builder.Dispose();
                    });
                    builder.Show();
                }
                else
                {
                   // var action = GetFeedBackAsync();
                }
            };
            alertDialog.Show();
        }

        //public async Task GetFeedBackAsync()
        //{
        //    //var remotearg = await revokeViewModel.InsertRevokeReason(revokeRequestModel);
        //    //if ()
        //}
    }
}