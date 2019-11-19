using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class ResignationDetail
    {
        public ResignationDetailTable detailTable;
    }

    [Table("Resignation")]
    public class ResignationDetailTable : BaseTable
    {
        
        [PrimaryKey]
        [Column("employeeResignationId")]
        public int employeeResignationId { get; set; }

            [Column("hrId")]
            public int hrId { get; set; }

            [Column("rmId")]
            public int rmId { get; set; }

            [Column("approvedByHr")]
            public bool IsApprovedByHr { get; set; }

            [Column("approvedByRm")]
            public bool IsApprovedByRm { get; set; }

            [Column("resignationRequestDate")]
            public DateTime resignationRequestDate { get; set; }

            [Column("resignationApprovalDate")]
            public DateTime resignationApprovalDate { get; set; }

            [Column("onBoardingNoticePeriod")]
            public int onBoardingNoticePeriod { get; set; }

            [Column("proposedNoticePeriod")]
            public int proposedNoticePeriod { get; set; }
            
            [Column("approvedNoticePeriod")]
            public int approvedNoticePeriod { get; set; }
            
            [Column("employeeResignationAppliedDate")]
            public DateTime employeeResignationAppliedDate { get; set; }

            [Column("resignationReason")]
            public string resignationReason { get; set; }

            [Column("status")]
            public string status { get; set; }

            [Column("revokeReason")]
            public string revokeReason { get; set; }

            [Column("rmRemarks")]
            public string rmRemarks { get; set; }

            [Column("hrRemarks")]
            public string hrRemarks { get; set; }

            [Ignore]
            public List<string> ccPersons { get; set; }
    }

}
