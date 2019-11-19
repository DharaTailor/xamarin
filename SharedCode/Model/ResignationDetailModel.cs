using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public class ResignationDetailModel
    {
        [JsonProperty("employeeId")]
        public int employeeId { get; set; }

        [JsonProperty("employeeResignationId")]
        public int employeeResignationId { get; set; }

        [JsonProperty("hrId")]
        public object hrId { get; set; }

        [JsonProperty("rmId")]
        public object rmId { get; set; }

        [JsonProperty("IsApprovedByHr")]
        public bool IsApprovedByHr { get; set; }

        [JsonProperty("IsApprovedByRm")]
        public bool IsApprovedByRm { get; set; }

        [JsonProperty("resignationRequestDate")]
        public DateTime resignationRequestDate { get; set; }

        [JsonProperty("resignationApprovalDate")]
        public object resignationApprovalDate { get; set; }

        [JsonProperty("onBoardingNoticePeriod")]
        public int onBoardingNoticePeriod { get; set; }

        [JsonProperty("proposedNoticePeriod")]
        public int proposedNoticePeriod { get; set; }

        [JsonProperty("approvedNoticePeriod")]
        public object approvedNoticePeriod { get; set; }

        [JsonProperty("requestDate")]
        public DateTime requestDate { get; set; }

        [JsonProperty("resignationReason")]
        public string resignationReason { get; set; }

        [JsonProperty("status")]
        public byte status { get; set; }

        [JsonProperty("feedback")]
        public string feedback { get; set; }

        [JsonProperty("revokeReason")]
        public object revokeReason { get; set; }

        [JsonProperty("rmRemarks")]
        public object rmRemarks { get; set; }

        [JsonProperty("hrRemarks")]
        public object hrRemarks { get; set; }

        [JsonProperty("exitInterviewDate")]
        public object exitInterviewDate { get; set; }

        [JsonProperty("ccPersons")]
        public List<string> ccPersons { get; set; }

    }

    public class Resignation
    {
        public List<ResignationDetailModel> ResignationModelList { get; set; }
    }
}
