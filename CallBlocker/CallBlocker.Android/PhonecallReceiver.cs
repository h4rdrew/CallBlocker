using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Telecom;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Java.Lang.Reflect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallBlocker.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged })]
    public class PhonecallReceiver : BroadcastReceiver
    {
        string manufacturer = Build.Manufacturer;
        string model = Build.Model;
        int version = (int)Build.VERSION.SdkInt;
        int versionRelease = Convert.ToInt32(Build.VERSION.Release);

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
            {
                var state = intent.GetStringExtra(TelephonyManager.ExtraState);
                if (state == TelephonyManager.ExtraStateRinging && versionRelease >= 9)
                {
                    var number = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    TelecomManager telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);

                    telecomManager.EndCall();

                }

                if (state == TelephonyManager.ExtraStateRinging && versionRelease < 9)
                {
                    //var number = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    ////callScreeningService
                    //TelecomManager telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);


                    //TelephonyManager tm = (TelephonyManager)context.GetSystemService(Context.TelephonyService);

                    //try
                    //{
                    //    Method m = tm.Class.GetDeclaredMethod("getITelephony");

                    //    m.Accessible = true;
                    //    telephonyService = (ITelephony)m.Invoke(tm);

                    //    if (number != null)
                    //    {
                    //        telephonyService.EndCall();
                    //        Toast.MakeText(context, "Ending the call from: " + number, ToastLength.Short).Show();
                    //    }

                    //}
                    //catch (Exception)
                    //{
                    //    throw;
                    //}
                }
            }
        }
    }
}