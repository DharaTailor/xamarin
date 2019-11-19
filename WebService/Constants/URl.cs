using System;
using System.Collections.Generic;
using System.Text;

namespace WebService
{
    public class URL
    {
        public const string Apply = URL_Environment.Connection + "/api/resignations/apply";
        public const string CcPerson = URL_Environment.Connection + "/api/resignations/ccpersons";
        public const string ResignationDetail = URL_Environment.Connection + "/api/resignations/details";
        public const string RevokeRequest = URL_Environment.Connection + "/api/resignations/revoke";
        public const string ExitCheckListDetail = URL_Environment.Connection + "/api/exitActivityDetails/{exitActivityId}";
        public const string FeedBack = URL_Environment.Connection + "/api/resignations";
    }

    public static class URLReplace
    {
        public static string EmployeeId(string url, string exitActivityId)
        {
            return url.Replace("{exitActivityId}", exitActivityId);
        }
    }
}
