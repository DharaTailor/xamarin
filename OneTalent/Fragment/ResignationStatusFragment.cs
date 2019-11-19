using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using SharedCode;
using Utility;

namespace OneTalent
{
    public class ResignationStatusFragment : Fragment
    {
        TextView textViewTitle;
        TextView textViewStatus;
        TextView editTextCurrenrtDate;
        TextView editTextProposedDate;
        LinearLayout linearApprovedDate;
        TextView editTextApproveDate;
        TextView editTextCCPerson;
        LinearLayout linearOnBoardNotice;
        TextView editOnBoardNotice;
        LinearLayout linearProposedNotice;
        TextView editProposedNotice;
        LinearLayout linearApprovedNotice;
        TextView editApprovedNotice;
        TextView editTextReason;
        LinearLayout linearRMRemark;
        TextView editTextRMRemark;
        LinearLayout linearHRRemark;
        TextView editTextHRRemark;
        Button buttonRevoke;
        ImageView imageBack;
        Android.Support.V7.Widget.Toolbar toolbar;
        ResignationDetailModel resignationDetailModel;
        ResignationDetailViewModel resignationDetailView;
        int resignationID;
        List<ResignationDetailModel> resignationDetailsList;
        List<string> CcPersonList;
        RevokeViewModel revokeViewModel;
        RevokeRequestModel revokeRequestModel;
        FragmentTransaction transaction;
        DateTime currentDate;
        LinearLayout linearCCPerson;
        TextView exitCheckListStatus;
        LinearLayout linearFeedback;
        TextView feedback;
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            resignationID = Arguments.GetInt("resignationId");

        }

        public override void OnResume()
        {
            base.OnResume();
            var action = GetAllDetails();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.ResignationStatus, container, false);
            UIReference(view);
            UIClick();
            SetUpToolbar();
            resignationDetailModel = new ResignationDetailModel();
            resignationDetailView = new ResignationDetailViewModel();
         
            return view;
        }

        private async Task GetAllDetails()
        {
            resignationDetailsList = new List<ResignationDetailModel>();
            ProgressIndicator.Show(Context);
            resignationDetailsList = await resignationDetailView.GetResignationDetails();
            ProgressIndicator.Hide();
            foreach(var item in resignationDetailsList)
            {
                if (resignationID == item.employeeResignationId)
                {
                    currentDate = item.requestDate;
                    editTextCurrenrtDate.Text = currentDate.ToString("dd/MM/yyyy");
                    editTextProposedDate.Text = item.resignationRequestDate.ToString("dd/MM/yyyy");
                    //CC Person
                    CcPersonList = new List<string>();
                    foreach (var items in item.ccPersons)
                    {
                        CcPersonList.Add(items);
                    }
                    if (CcPersonList.Count == 0)
                    {
                        linearCCPerson.Visibility = ViewStates.Gone;
                    }
                    for (int i = 0; i < CcPersonList.Count; i++)
                    {
                        if(CcPersonList.Count<=1)
                        {
                            linearCCPerson.Visibility = ViewStates.Visible;
                            editTextCCPerson.Text = CcPersonList.ElementAt(i).ToString();
                        }
                        
                        else
                        {
                            linearCCPerson.Visibility = ViewStates.Visible;
                            editTextCCPerson.Text = editTextCCPerson.Text + " " + CcPersonList.ElementAt(i).ToString() + ",";
                        }

                    }
                    //ExitCheckList Status
                    if(item.status==Convert.ToByte(StatusEnum.statusEnum.InProgress))
                    {
                        exitCheckListStatus.Visibility = ViewStates.Visible;
                        exitCheckListStatus.Text = StatusEnum.statusEnum.InProgress.ToString();
                        if(item.feedback !="")
                        {
                            linearFeedback.Visibility = ViewStates.Visible;
                            feedback.Text = item.feedback.ToString();
                        }
                    }
                    //
                    editTextReason.Text = item.resignationReason;
                    
                    if (item.onBoardingNoticePeriod != 0)
                    {
                        linearOnBoardNotice.Visibility = ViewStates.Visible;
                        editOnBoardNotice.Text = item.onBoardingNoticePeriod.ToString();
                    }
                    else
                    {
                        linearOnBoardNotice.Visibility = ViewStates.Gone;
                    }

                    if (item.proposedNoticePeriod != 0)
                    {
                        linearProposedNotice.Visibility = ViewStates.Visible;
                        editProposedNotice.Text = item.proposedNoticePeriod.ToString();
                    }
                    else
                    {
                        linearProposedNotice.Visibility = ViewStates.Gone;
                    }

                    if (item.status==Convert.ToByte(StatusEnum.statusEnum.AcceptedByHR))
                    {
                        textViewStatus.Text = StatusEnum.statusEnum.AcceptedByHR.ToString();
                        buttonRevoke.Visibility = ViewStates.Gone;

                        if ((string)item.hrRemarks != "")
                        {

                            linearHRRemark.Visibility = ViewStates.Visible;
                            editTextHRRemark.Text = item.hrRemarks.ToString();
                        }
                        else
                        {
                            linearHRRemark.Visibility = ViewStates.Gone;
                        }

                        if ((string)item.rmRemarks != "")
                        {
                            linearRMRemark.Visibility = ViewStates.Visible;
                            editTextRMRemark.Text = item.rmRemarks.ToString();
                        }
                        else
                        {
                            linearRMRemark.Visibility = ViewStates.Gone;
                        }
                        if (Convert.ToInt32(item.approvedNoticePeriod) != 0)
                        {
                            linearApprovedNotice.Visibility = ViewStates.Visible;
                            editApprovedNotice.Text = item.approvedNoticePeriod.ToString();
                        }
                        else
                        {
                            linearApprovedNotice.Visibility = ViewStates.Gone;
                        }
                        if (Convert.ToDateTime(item.resignationApprovalDate) != null)
                        {
                            linearApprovedDate.Visibility = ViewStates.Visible;
                            editTextApproveDate.Text = item.resignationApprovalDate.ToString();
                        }
                        else
                        {
                            linearApprovedDate.Visibility = ViewStates.Gone;
                        }
                    }
                    else if (item.status==Convert.ToByte(StatusEnum.statusEnum.AcceptedByRM))
                    {
                        textViewStatus.Text = StatusEnum.statusEnum.AcceptedByRM.ToString();
                        if ((string)item.rmRemarks != "")
                        {
                            linearRMRemark.Visibility = ViewStates.Visible;
                            editTextRMRemark.Text = item.rmRemarks.ToString();
                        }
                        else
                        {
                            linearRMRemark.Visibility = ViewStates.Gone;
                        }
                    }
                    else if (item.status==Convert.ToByte(StatusEnum.statusEnum.RejectedByRM))
                    {
                        textViewStatus.Text = StatusEnum.statusEnum.RejectedByRM.ToString();
                        buttonRevoke.Visibility = ViewStates.Gone;
                        if ((string)item.rmRemarks != "")
                        {
                            linearRMRemark.Visibility = ViewStates.Visible;
                            editTextRMRemark.Text = item.rmRemarks.ToString();
                        }
                        else
                        {
                            linearRMRemark.Visibility = ViewStates.Gone;
                        }
                    }
                    else if(item.status==Convert.ToByte(StatusEnum.statusEnum.RejectedByHR))
                    {
                        textViewStatus.Text = StatusEnum.statusEnum.RejectedByHR.ToString();
                        buttonRevoke.Visibility = ViewStates.Gone;

                        if ((string)item.hrRemarks != "")
                        {

                            linearHRRemark.Visibility = ViewStates.Visible;
                            editTextHRRemark.Text = item.hrRemarks.ToString();
                        }
                        else
                        {
                            linearHRRemark.Visibility = ViewStates.Gone;
                        }

                        if ((string)item.rmRemarks != "")
                        {
                            linearRMRemark.Visibility = ViewStates.Visible;
                            editTextRMRemark.Text = item.rmRemarks.ToString();
                        }
                        else
                        {
                            linearRMRemark.Visibility = ViewStates.Gone;
                        }
                    }
                    else if (item.status==Convert.ToByte(StatusEnum.statusEnum.Revoked))
                    {
                        textViewStatus.Text = StatusEnum.statusEnum.Revoked.ToString();
                        buttonRevoke.Visibility = ViewStates.Gone;
                    }
                    else
                    {
                        textViewStatus.Text = StatusEnum.statusEnum.Initiated.ToString();
                    } 
                }
            }
        }

        private void SetUpToolbar()
        {
            textViewTitle.Text = Message.ResignationDetail;
        }

        private void UIReference(View v)
        {
            toolbar = v.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.resignationStatusToolbar);
            textViewTitle = v.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
            textViewStatus = v.FindViewById<TextView>(Resource.Id.textViewStatus);
            editTextCurrenrtDate = v.FindViewById<TextView>(Resource.Id.editCurrentDate);
            editTextProposedDate = v.FindViewById<TextView>(Resource.Id.editResignDate);
            linearApprovedDate = v.FindViewById<LinearLayout>(Resource.Id.linearAppovedDate);
            editTextApproveDate = v.FindViewById<TextView>(Resource.Id.editApprovedDate);
            editTextCCPerson = v.FindViewById<TextView>(Resource.Id.editCCPerson);
            linearOnBoardNotice = v.FindViewById<LinearLayout>(Resource.Id.onboardNotice);
            editOnBoardNotice = v.FindViewById<TextView>(Resource.Id.editOnBoardNotice);
            linearProposedNotice = v.FindViewById<LinearLayout>(Resource.Id.proposedNotice);
            editProposedNotice = v.FindViewById<TextView>(Resource.Id.editProposedNotice);
            linearApprovedNotice = v.FindViewById<LinearLayout>(Resource.Id.approvedNoticePeriod);
            editApprovedNotice = v.FindViewById<TextView>(Resource.Id.editApproveNotice);
            editTextReason = v.FindViewById<TextView>(Resource.Id.editReason);
            linearRMRemark = v.FindViewById<LinearLayout>(Resource.Id.linearRMRemark);
            editTextRMRemark = v.FindViewById<TextView>(Resource.Id.editRMRemarks);
            linearHRRemark = v.FindViewById<LinearLayout>(Resource.Id.linearHRRemark);
            editTextHRRemark = v.FindViewById<TextView>(Resource.Id.editHRRemarks);
            buttonRevoke = v.FindViewById<Button>(Resource.Id.buttonRevoke);
            imageBack = v.FindViewById<ImageView>(Resource.Id.backButton);
            linearCCPerson = v.FindViewById<LinearLayout>(Resource.Id.linearCCPerson);
            exitCheckListStatus = v.FindViewById<TextView>(Resource.Id.exitCheckListStatus);
            linearFeedback = v.FindViewById<LinearLayout>(Resource.Id.linearFeedback);
            feedback = v.FindViewById<TextView>(Resource.Id.feedback);
        }

        private void UIClick()
        {
            buttonRevoke.Click += ButtonRevoke_Click;
            imageBack.Click += ImageBack_Click;
        }

        private void ImageBack_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frameLayout, new ApplyFragment());
            transaction.AddToBackStack(null);
            transaction.Commit();
        }

        private void ButtonRevoke_Click(object sender, EventArgs e)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.revokeDialogFragment, null);
            Android.App.AlertDialog alertDialog = new Android.App.AlertDialog.Builder(Context).Create();
            alertDialog.SetView(view);
            Button cancelButton, SaveButton;
            EditText saveRevoke;
            TextView requestdate;
            SaveButton = view.FindViewById<Button>(Resource.Id.buttonSave);
            cancelButton = view.FindViewById<Button>(Resource.Id.buttonCancel);
            saveRevoke = view.FindViewById<EditText>(Resource.Id.editRevoke);
            requestdate = view.FindViewById<TextView>(Resource.Id.textView1);
            requestdate.Text = "Enter Reason to Revoke the Resignation Request made on " + currentDate.ToString("dd/MM/yyyy");
            cancelButton.Click += delegate
            {
                alertDialog.Dismiss();
            };
            SaveButton.Click += delegate
            {
               
                revokeRequestModel = new RevokeRequestModel
                {
                    revokeReason = saveRevoke.Text
                };

                var result = ModelValidator.Validate(revokeRequestModel);
                if (result != null && !result.Result)
                {
                    Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(Context);
                    builder.SetMessage(result.Message.ToString());
                    builder.SetPositiveButton("OK", (s, a) =>
                    {
                        builder.Dispose();
                    });
                    builder.SetCancelable(false);
                    builder.Show();
                }
                else
                {
                    var action = GetRevoke();
                   
                }
                alertDialog.Dismiss();
            };
            alertDialog.Show();
        }

        public async Task GetRevoke()
        {
            revokeViewModel = new RevokeViewModel();
            var remotearg = await revokeViewModel.InsertRevokeReason(revokeRequestModel);
            if (remotearg.Result)
            {

                transaction = FragmentManager.BeginTransaction();
                transaction.Replace(Resource.Id.frameLayout, new ApplyFragment());
                transaction.AddToBackStack(null);
                transaction.Commit();
            }
            else
            {
                Toast.MakeText(Context, "Can't be Revoke", ToastLength.Long).Show();
            }
        }
    }
}