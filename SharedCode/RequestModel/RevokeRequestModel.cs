using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SharedCode
{
    public class RevokeRequestModel:DataModel
    {
        [Required(ErrorMessage = "Revoke is Required")]
        [StringLength(250, MinimumLength = 25, ErrorMessage = "Reason Field must be between {2} to {1} characters")]
        public string revokeReason { get; set; }
    }
}
