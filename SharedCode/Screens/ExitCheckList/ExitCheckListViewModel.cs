using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class ExitCheckListViewModel
    {
        ExitCheckListViewDataProvider exitCheckListViewDataProvider;
        public ExitCheckListViewModel()
        {
            exitCheckListViewDataProvider = new ExitCheckListViewDataProvider();
        }

        public async Task<List<ExitCheckListDetailModel>> GetExitCheckListAsync()
        {
            return await exitCheckListViewDataProvider.GetExitCheckListDetailsAsync();
        }


        public async Task<RemoteArgs> GetFeedBackAsync(DataModel dataModel)
        {
            return await exitCheckListViewDataProvider.GetFeedBack(dataModel); 
        }
    }
}
