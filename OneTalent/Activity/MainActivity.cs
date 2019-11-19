
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.App;
using Android.Support.Design.Widget;
using Utility;

namespace OneTalent
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/onetalent_icon")]
    public class MainActivity : AppCompatActivity
    {
        MyOauth2Authenticator myOauth2Authenticator;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Authetication();
        }

        public void Authetication()
        {
            var auth = new MyOauth2Authenticator(
                 "1TalentMobile",
                 "secret",
                 "openid profile 1TalentApi",
                 new Uri("http://192.168.0.254:8043/connect/authorize"),
                 new Uri("com.onetalent.onetalent:/callback"),
                 new Uri("http://192.168.0.254:8043/connect/token")
                );
            auth.AllowCancel = true;
            auth.Completed += (s, e) => {
                if (e.IsAuthenticated)
                {
                    var token = e.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToInt32(e.Account.Properties["expires_in"]);
                    var expireDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);
                    Preference.Token = token;
                    Preference.ExpireTokenTime = expiresIn;
                    StartActivity(typeof(DashBoardActivity));
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Error Authentication", ToastLength.Short).Show();
                }
            };
            var activity = auth.GetUI(this);
            StartActivity(activity);
        }
    }
}