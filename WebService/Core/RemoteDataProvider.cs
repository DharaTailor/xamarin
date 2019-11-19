using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace WebService
{
    public class RemoteDataProvider
    {
        Service _service;

        public RemoteDataProvider()
        {
            _service = new Service();
        }

        public async Task<RemoteArgs> ExecuteAsync(ServiceMethod method, string url, string model = null)
        {
            RequestModel requestModel = new RequestModel
            {
                Url = url,
                Body = model,
                Method = method
            };
            var response = await _service.ExecuteAsync(requestModel);
            return HandleResponse(response);
        }

        RemoteArgs HandleResponse(ResponseModel response)
        {
            RemoteArgs remoteArgs = new RemoteArgs
            {
                Message = response.Message,
                Content = response.Body
            };
            if (response.Result == RemoteResult.Success)
            {
                remoteArgs.Result = true;
            }
            else
            {
                remoteArgs.Result = false;
            }
            return remoteArgs;
        }
    }
}
