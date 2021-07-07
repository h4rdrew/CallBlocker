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
    public class PhonecallReceiver : BroadcastReceiver, TextToSpeech.IOnInitListener
    {
        //private ITelephony telephonyService;

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
            {
                var state = intent.GetStringExtra(TelephonyManager.ExtraState);
                if (state == TelephonyManager.ExtraStateRinging)
                {
                    var number = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    TelecomManager telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);
                    telecomManager.EndCall();

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

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            throw new NotImplementedException();
        }
    }
}