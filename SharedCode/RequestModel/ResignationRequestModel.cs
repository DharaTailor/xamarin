using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Utility;
using Newtonsoft.Json;

namespace SharedCode
{
    public class ResignationRequestModel : DataModel
    {

        [Required(ErrorMessage = "Relieve Date is Required")]
        public string relieveDate { get; set; }

        [Required(ErrorMessage = "Reason is Required")]
        [StringLength(250,MinimumLength = 25, ErrorMessage = "Reason Field must be between {2} to {1} characters")]
        [JsonProperty("reason")]
        public string ReasonForRelieve { get; set; }

        [JsonProperty("ccPersons")]
        public List<int> ConcernPerson { get; set; }
    }
}
