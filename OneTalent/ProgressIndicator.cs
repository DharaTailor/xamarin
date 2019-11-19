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
    public static class ProgressIndicator
    {
        static ProgressDialog dialog;
        
        public static void Show(Context context)
        {
            dialog = new ProgressDialog(context);
            dialog.SetMessage("Please Wait...");
            dialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            dialog.SetCancelable(false);
            dialog.Show();
        }

        public static void Hide()
        {
            dialog.Hide();
        }

    }
}