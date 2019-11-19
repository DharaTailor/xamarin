using SharedCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WebService;

namespace SharedCode
{
    public class AppService
    {
        WebService _webService;
        
        public AppService()
        {
            _webService = new WebService();
        }

        ///<summary>
        ///ExecuteApplyResignationAsync
        ///</summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<RemoteArgs> ExecuteApplyResignationAsync(DataModel model)
        {
            return await _webService.ExecuteAsync(ServiceMethod.Post, URL.Apply, model);
        }

        ///<summary>
        ///ExecuteResignationDetail
        ///</summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<RemoteArgs> ExecuteResignationDetail()
        {
            return await _webService.ExecuteAsync(ServiceMethod.Get, URL.ResignationDetail);
        }

        ///<summary>
        ///ExecuteRevokeReason
        ///</summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<RemoteArgs> ExecuteRevokeReason(DataModel model)
        {
            return await _webService.ExecuteAsync(ServiceMethod.Put, URL.RevokeRequest,model);
        }

        ///<summary>
        ///ExecuteCCPersonAsync
        ///</summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<RemoteArgs> ExecuteCCPersonAsync()
        {
            return await _webService.ExecuteAsync(ServiceMethod.Get, URL.CcPerson);
        }

        ///<summary>
        ///ExecuteCCPersonAsync
        ///</summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<RemoteArgs> ExecuteExitCheckListAsync()
        {
            return await _webService.ExecuteAsync(ServiceMethod.Get, URL.ExitCheckListDetail);
        }

        ///<summary>
        ///ExecuteFeedbackAsync
        ///</summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public async Task<RemoteArgs> ExcecuteFeedbackAsync(DataModel dataModel)
        {
            return await _webService.ExecuteAsync(ServiceMethod.Put, URL.FeedBack, dataModel);
        }
    }
}
