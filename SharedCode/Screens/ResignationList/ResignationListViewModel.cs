using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedCode
{
   public class ResignationListViewModel
    {
        ResignationListViewDataProvider resignationListViewDataProvider;
        public ResignationListViewModel()
        {
            resignationListViewDataProvider = new ResignationListViewDataProvider();
        }

        public async Task<List<ResignationDetailModel>> GetDetailsList()
        {
            return await resignationListViewDataProvider.GetResignationDetailList();
        }
    }
}
