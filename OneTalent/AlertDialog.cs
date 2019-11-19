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

namespace OneTalent
{
    public static class AlertDialogPopup
    {
        static Context context;
        public static void Alert(string result)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(context);
            builder.SetMessage(result.ToString());
            builder.SetPositiveButton("OK", (s, a) =>
            {
                builder.Dispose();
            });
            builder.Show();
        }
    }
}