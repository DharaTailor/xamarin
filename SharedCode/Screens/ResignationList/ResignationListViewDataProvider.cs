using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedCode
{
  public  class ResignationListViewDataProvider
    {
        AppService appService;
        public ResignationListViewDataProvider()
        {
            appService = new AppService();
        }

        public async Task<List<ResignationDetailModel>> GetResignationDetailList()
        {
            var remotearg = await appService.ExecuteResignationDetail();
            if (remotearg.Result)
            {
                var remoteArgs = JsonConvert.DeserializeObject<List<ResignationDetailModel>>(remotearg.Content);
                return remoteArgs;
            }
            return null;
        }
    }
}
