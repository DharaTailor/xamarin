using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Utility
{
    public static class StatusEnum
    {
        public enum statusEnum
        {
            
            Initiated= 1,

            [Display(Name ="Accepted By RM")]
            AcceptedByRM = 2,

            [Display(Name ="Rejected By RM")]
            RejectedByRM = 3,
            
            Revoked = 4,

            [Display(Name ="Accepted By HR")]
            AcceptedByHR = 5,

            [Display(Name ="Rejected By HR")]
            RejectedByHR = 6,
            Closed = 7,
            NotStarted = 8,
            InProgress = 9,
            Completed = 10
        }
    }
}