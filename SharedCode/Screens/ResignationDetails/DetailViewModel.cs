using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class ResignationDetailViewModel
    {
        ResignationDetailViewDataProvider detailViewDataProvider;

        public ResignationDetailViewModel()
        {
            detailViewDataProvider = new ResignationDetailViewDataProvider();
        }

        public async Task<List<ResignationDetailModel>> GetResignationDetails()
        {
            return await detailViewDataProvider.GetResignationDetailList();
        }
    }
}
