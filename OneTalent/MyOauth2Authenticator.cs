using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Auth;

namespace OneTalent
{
    public class MyOauth2Authenticator : OAuth2Authenticator
    {
        string ClientID;
        string ClientSecret;
        string Scope;
        Uri AuthorizeUrl;
        Uri RedirectUrl;
        Uri AccessTokenUrl;
        
        public MyOauth2Authenticator(string clientId, string clientSecret, string scope, Uri authorizeUrl, Uri redirectUrl, Uri accessTokenUrl, GetUsernameAsyncFunc getUsernameAsync = null, bool isUsingNativeUI = false) : base(clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl, getUsernameAsync, isUsingNativeUI)
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
            Scope = scope;
            AuthorizeUrl = authorizeUrl;
            RedirectUrl = redirectUrl;
            AccessTokenUrl = accessTokenUrl;
        }

        protected override void OnCreatingInitialUrl(IDictionary<string, string> query)
        {
            query.Add("acr_values", "tenant:2A3DF6F5-9D38-44BD-B5D7-98DD6A1CE514");
        }
    }
}