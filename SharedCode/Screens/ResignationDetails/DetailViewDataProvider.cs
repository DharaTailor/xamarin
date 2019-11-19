using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class ResignationDetailViewDataProvider
    {
        AppService appService;
      
        public ResignationDetailViewDataProvider()
        {
            appService = new AppService();
           
        }

        public async Task<List<ResignationDetailModel>> GetResignationDetailList()
        {
            var remotearg = await appService.ExecuteResignationDetail();
            if (remotearg.Result)
            {
                var resignationDetail = JsonConvert.DeserializeObject<List<ResignationDetailModel>>(remotearg.Content);
                return resignationDetail;
            }
            return null;
        }
    }
}
