using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
   public  class ExitCheckListDetailModel 
    {
        public int resignationId { get; set; }
        public int exitActivityId { get; set; }
        public string employeeName { get; set; }
        public string approvedRelieveDate { get; set; }
        public string initiatedOn { get; set; }
        public string activityName { get; set; }
        public string domainName { get; set; }
        public string description { get; set; }
        public string assignedName { get; set; }
        public int status { get; set; }
        public List<Remark> remarks { get; set; }
    }

    public class Remark
    {
        public string remark { get; set; }
    }
}
