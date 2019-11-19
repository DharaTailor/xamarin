using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class RevokeViewDataProvider
    {
        AppService appService;

        public RevokeViewDataProvider()
        {
            appService = new AppService();
        }

        public async Task<RemoteArgs> InsertRevokeReason(DataModel model)
        {
            var remotearg = await appService.ExecuteRevokeReason(model);
            return remotearg;
        }
    }
}
