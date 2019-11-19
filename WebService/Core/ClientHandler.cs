using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Utility;

namespace WebService
{
    public static class ClientHandler
    {
        public static HttpClient GetAuthenticatedClient()
        {
            HttpClient httpClient;

            var token = Preference.Token;

            if (!string.IsNullOrEmpty(token))
            {
                var auth = new AuthenticationHeaderValue("Bearer", token);

                httpClient = new HttpClient
                {
                    DefaultRequestHeaders = { Authorization = auth}
                };
                return httpClient;
            }
            else
            {
                return new HttpClient();
            }
        }
    }
}
