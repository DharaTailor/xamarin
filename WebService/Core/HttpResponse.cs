using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class HttpResponse
    {
        public RemoteResult Result { get; set; }
        public string HttpMessage { get; set; }
        public string HttpContent { get; set; }

        public async Task HandleResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var content = await response.Content.ReadAsStringAsync();
                    CheckCommonResponse(content);
                    break;

                case HttpStatusCode.Unauthorized:
                    Result = RemoteResult.Failed;
                    HttpMessage = Message.Unauthorized;
                    break;

                case HttpStatusCode.NoContent:
                    Result = RemoteResult.Failed;
                    HttpMessage = Message.InValid;
                    break;

                default:
                    Result = RemoteResult.Failed;
                    HttpMessage = Message.InValid;
                    break;
            }
        }

        private void CheckCommonResponse(string content)
        {
            try
            {
                HttpContent = content;
                Result = RemoteResult.Success;
                HttpMessage = "Sucessfull";
            }
            catch (Exception e)
            {
                Result = RemoteResult.Failed;
                HttpMessage = e.Message;
            }
        }
    }
}
