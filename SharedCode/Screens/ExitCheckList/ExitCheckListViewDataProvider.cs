using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class ExitCheckListViewDataProvider
    {
        AppService appService;
        public ExitCheckListViewDataProvider()
        {
            appService = new AppService();
        }

        public async Task<List<ExitCheckListDetailModel>> GetExitCheckListDetailsAsync()
        {
            var remoteargs = await appService.ExecuteExitCheckListAsync();
            if(remoteargs.Result)
            {
                var remoteArgs = JsonConvert.DeserializeObject<List<ExitCheckListDetailModel>>(remoteargs.Content);
                return remoteArgs;
            }
            return null;
        }

        public async Task<RemoteArgs> GetFeedBack(DataModel dataModel)
        {
            return await appService.ExcecuteFeedbackAsync(dataModel);
        }
    }
}
