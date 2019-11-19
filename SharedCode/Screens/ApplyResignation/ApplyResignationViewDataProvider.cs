using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class ApplyResignationViewDataProvider
    {
        AppService appService;

        public ApplyResignationViewDataProvider()
        {
            appService = new AppService();
        }

        public async Task<RemoteArgs> ApplyResignationAsync(DataModel model)
        {
            var remotearg = await appService.ExecuteApplyResignationAsync(model);
            return remotearg;
        }

        public async Task<List<Employee>> GetCcPersonAsync()
        {
            var remotearg = await appService.ExecuteCCPersonAsync();
            if (remotearg.Result)
            {
                var concenPersonList = JsonConvert.DeserializeObject<List<Employee>>(remotearg.Content);
                return concenPersonList;
            }
            return null;
        }

    }
}
