using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WebService;

namespace SharedCode
{
    public class WebService
    {
        RemoteDataProvider remoteDataProvider;

        public WebService()
        {
            remoteDataProvider = new RemoteDataProvider();
        }

        public async Task<RemoteArgs> ExecuteAsync(ServiceMethod method, string url, DataModel model)
        {
            var data = JsonConvert.SerializeObject(model);
            return await remoteDataProvider.ExecuteAsync(method, url, data);
        }

        public async Task<RemoteArgs> ExecuteAsync(ServiceMethod method, string url, string model = null)
        {
            return await remoteDataProvider.ExecuteAsync(method, url, model);
        }
    }
}
