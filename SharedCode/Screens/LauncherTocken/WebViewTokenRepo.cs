using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace SharedCode
{
     public class WebViewTokenRepo
    {
        TokenRepo _token;
        public string Message { get; set; }

        public WebViewTokenRepo()
        {
            _token = new TokenRepo();
        }

        /// <summary>
        /// Insert Token into Database 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool InsertToken(string token)
        {
            var model = JsonConvert.DeserializeObject<TokenTable>(token);
            if (_token.InsertOrUpdate(model))
            {
                Preference.Token = model.Token;
                Message = "";
                return true;
            }
            else
            {
                Message = _token.Message;
                return false;
            }
        }
    }
}
