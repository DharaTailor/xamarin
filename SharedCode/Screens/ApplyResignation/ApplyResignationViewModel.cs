using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SharedCode
{
    public class ApplyResignationViewModel
    {
        ApplyResignationViewDataProvider resignationViewDataProvider;

        public ApplyResignationViewModel()
        {
            resignationViewDataProvider = new ApplyResignationViewDataProvider();
        }

        public async Task<RemoteArgs> ActionApplyResignationAsync(DataModel model)
        {
            return await resignationViewDataProvider.ApplyResignationAsync(model);
        }

        public async Task<List<Employee>> ActionCcPersonAsync()
        {
            return await resignationViewDataProvider.GetCcPersonAsync();
        }
    }
}
