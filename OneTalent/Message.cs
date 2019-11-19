using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OneTalent
{
    public class Message
    {
        public const string NotApplyed = "You have not applied for resignation yet";
        public const string ResignationDetail = "Resignation Details";
        public const string ResignationApply = "Resignation Status";
        public const string ResignationApplyForm = "Resignation Request Form";
        public const string DashBoard = "Dashboard";
        public const string RequestSuccessMessage = "Resignation Request Sent Successfully";
        public const string BadRequestMessage = "Cannot Apply";
        public const string ExitCheckList = "Exit CheckList";
        public const string ExitCheckListDetail = "Exit CheckList Details";
        public const string NotApprovedByHR = "Not Approved By HR";
    }
}