using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
   public  class RevokeViewModel
    {
        RevokeViewDataProvider revokeViewDataProvider;
        public RevokeViewModel()
        {
            revokeViewDataProvider = new RevokeViewDataProvider();
        }

       public async Task<RemoteArgs> InsertRevokeReason(DataModel model)
        {
            return await revokeViewDataProvider.InsertRevokeReason(model);
        }
    }
}
