using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SharedCode
{
    public class FeedBackRequestModel : DataModel
    {
        [Required(ErrorMessage = "FeedBack cannot be empty")]
        [StringLength(250,MinimumLength =0, ErrorMessage = "Feedback field must be between {2} to {1} characters")]
        public string feedback { get; set; }
    }
}
