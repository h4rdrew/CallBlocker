using Android.App;
using Android.Content;
using Android.OS;
using Android.Telecom;
using Android.Telephony;
using System;

namespace CallBlocker.Droid
{

    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged })]

    public class PhonecallReceiver : BroadcastReceiver
    {

        //string manufacturer = Build.Manufacturer;
        //string model = Build.Model;
        //int version = (int)Build.VERSION.SdkInt;
        decimal versionRelease = Convert.ToDecimal(Build.VERSION.Release);
        //CallScreeningService call;
        
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
            {
                var state = intent.GetStringExtra(TelephonyManager.ExtraState);
                if (state == TelephonyManager.ExtraStateRinging && versionRelease >= 9)
                {
                    //var number = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    TelecomManager telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);
                    telecomManager.EndCall();
                    
                }

                if (state == TelephonyManager.ExtraStateRinging && versionRelease < 9)
                {
                    Call call = (Call)context.GetSystemService(Context.TelecomService);
                    call.Reject(false, "");

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