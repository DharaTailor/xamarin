using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using ImageViews.Rounded;
using Java.Lang;
using Java.Util;
using SharedCode;
using Utility;

namespace OneTalent
{
    public class ApplyResignationFragment : Fragment
    {
        TextView SelectDateEditText;
        EditText ReasonEditText;
        MultiAutoCompleteTextView CcpersonTextView;
        Button SubmitButton;
        Button ResetButton;
        TextView ApplyResignationTextView;
        RoundedImageView profileImage;
        ImageView backImage;
        Android.App.DatePickerDialog datePickerDialog;
        ApplyResignationViewModel applyResignationViewModel;
        public List<Employee> EmployeeList;
        public List<int> CcpersonIdList;
        public List<string> names;
        public List<string> data;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            var action = CcPersonDetail();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.ApplyResignationForm, container, false);
            UIReference(view);
            UIClick();
            profileImage.Visibility = ViewStates.Invisible;
            ApplyResignationTextView.Text = Message.ResignationApplyForm;
            return view;
        }

        private void UIReference(View v)
        {
            ApplyResignationTextView = v.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
            profileImage = v.FindViewById<RoundedImageView>(Resource.Id.roundProfileImage);
            backImage = v.FindViewById<ImageView>(Resource.Id.backButton);
            SelectDateEditText = v.FindViewById<TextView>(Resource.Id.DateEditText);
            ReasonEditText = v.FindViewById<EditText>(Resource.Id.ReasonEditText);
            CcpersonTextView = v.FindViewById<MultiAutoCompleteTextView>(Resource.Id.ccPersonEditText);
            SubmitButton = v.FindViewById<Button>(Resource.Id.submitButton);
            ResetButton = v.FindViewById<Button>(Resource.Id.resetButton);
        }

        private void UIClick()
        {
            SelectDateEditText.Click += SelectDateEditText_Click;
            ResetButton.Click += ResetButton_Click;
            SubmitButton.Click += SubmitButton_Click;
            backImage.Click += BackImage_Click;
        }

        private async Task CcPersonDetail()
        {
            EmployeeList = new List<Employee>();
            applyResignationViewModel = new ApplyResignationViewModel();
            EmployeeList = await applyResignationViewModel.ActionCcPersonAsync();
            ShowCcPersonDetails();
        }

        private void ShowCcPersonDetails()
        {
            names = new List<string>();
            foreach (var item in EmployeeList)
            {
                names.Add(item.employeeName);
            }
            ArrayAdapter adapter = new ArrayAdapter(Context, Resource.Layout.support_simple_spinner_dropdown_item, names);
            CcpersonTextView.Adapter = adapter;
            CcpersonTextView.Threshold = 1;
            CcpersonTextView.SetTokenizer(new MultiAutoCompleteTextView.CommaTokenizer());
        }

        public void GetCcPersonId()
        {
            CcpersonIdList = new List<int>();
            string CcPerson = CcpersonTextView.Text;
            string[] spitString = CcPerson.Split(",");
            data = new List<string>();
            foreach (var item in spitString)
            {
                if (item.Trim() != "")
                {
                    data.Add(item.TrimStart());
                }
            }
            foreach (var employee in data)
            {
                if (names.Contains(employee))
                {
                    int index = names.IndexOf(employee);
                    CcpersonIdList.Add(EmployeeList.Where(x=>x.employeeName == employee).Select(x=>x.employeeId).FirstOrDefault());
                }
            }
        }

        private void SelectDateEditText_Click(object sender, EventArgs e)
        {
            var dateTimeNow = DateTime.Now;
            datePickerDialog = new Android.App.DatePickerDialog(Context, OnDateSelected, dateTimeNow.Year, dateTimeNow.Month - 1, dateTimeNow.Day);
            datePickerDialog.DatePicker.MinDate = JavaSystem.CurrentTimeMillis() + 86400000;
            datePickerDialog.Show();
        }

        private void OnDateSelected(object sender, Android.App.DatePickerDialog.DateSetEventArgs e)
        {
            SelectDateEditText.Text = e.Date.ToString("yyyy-MM-dd");
        }

        private void BackImage_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frameLayout, new ApplyFragment());
            transaction.AddToBackStack(null);
            transaction.Commit();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var action = SaveData();
        }

        public async Task SaveData()
        {
            GetCcPersonId();
            ResignationRequestModel resignationRequest = new ResignationRequestModel
            {
                relieveDate = SelectDateEditText.Text,
                ReasonForRelieve = ReasonEditText.Text,
                ConcernPerson = CcpersonIdList
            };
            var result = ModelValidator.Validate(resignationRequest);
            if (result!=null && !result.Result)
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
                ProgressIndicator.Show(Context);
                var remoteArgs = await applyResignationViewModel.ActionApplyResignationAsync(resignationRequest);
                if (remoteArgs.Result)
                {
                    ProgressIndicator.Hide();
                    Toast.MakeText(Context, Message.RequestSuccessMessage, ToastLength.Long).Show();
                    ResetData();
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    ApplyFragment applyFragment = new ApplyFragment();
                    transaction.Replace(Resource.Id.frameLayout, applyFragment).Commit();
                }
                else
                {
                    ProgressIndicator.Hide();
                    Toast.MakeText(Context, Message.BadRequestMessage, ToastLength.Long).Show();
                }
            }
        }

        public void ResetData()
        {
            SelectDateEditText.Text = "";
            ReasonEditText.Text = "";
            CcpersonTextView.Text = "";
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetData();
        }
    }
}