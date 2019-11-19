using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility;


namespace WebService
{
    public enum ServiceMethod
    {
        Get,
        Post,
        Put,
        Delete
    }

    public class Service
    {
        HttpClient _httpClient;
        HttpResponse _httpResponse;
        public Service()
        {
            _httpClient = new HttpClient();
            _httpClient = ClientHandler.GetAuthenticatedClient();
            _httpResponse = new HttpResponse();
        }

        public async Task<ResponseModel> ExecuteAsync(RequestModel model)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    return SetContent(RemoteResult.Failed, Message.NoInternet);
                }

                var result = await GetResultAsync(model);
                return HandleResponse(result);
            }
            catch (Exception e)
            {
                return SetContent(RemoteResult.Failed, e.Message);
            }
        }

        ResponseModel SetContent(RemoteResult result, string message)
        {
            ResponseModel _content = new ResponseModel();
            _content.Result = result;
            _content.Message = message;

            return _content;
        }

        ResponseModel HandleResponse(HttpResponseMessage result)
        {
            ResponseModel content = new ResponseModel();

            var response = _httpResponse.HandleResponse(result);

            if (_httpResponse.Result == RemoteResult.Success)
            {
                content.Body = _httpResponse.HttpContent;
            }
            content.Result = _httpResponse.Result;
            content.Message = _httpResponse.HttpMessage;

            return content;
        }

        async Task<HttpResponseMessage> GetResultAsync(RequestModel model)
        {
            switch (model.Method)
            {
            
                case ServiceMethod.Get:
                    return await _httpClient.GetAsync(model.Url);
                case ServiceMethod.Post:
                    return await _httpClient.PostAsync(model.Url, new StringContent(model.Body, Encoding.UTF8, "application/json"));
                case ServiceMethod.Put:
                    return await _httpClient.PutAsync(model.Url, new StringContent(model.Body, Encoding.UTF8, "application/json"));
                case ServiceMethod.Delete:
                    return await _httpClient.DeleteAsync(model.Url);
            }

            return default;
        }
    }
}
