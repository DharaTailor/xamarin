using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Utility
{
    public static class Preference
    {
        public static string Token
        {
            get => Preferences.Get("EmployeeToken", "");
            set => Preferences.Set("EmployeeToken", value);
        }

        public static int ExpireTokenTime
        {
            get => Preferences.Get("ExpireTokenTime", 0);
            set => Preferences.Set("ExpireTokenTime", value);
        }
    }
}
