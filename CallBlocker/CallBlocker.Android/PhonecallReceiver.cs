using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Telephony;
using System;
using System.Collections.Generic;

namespace CallBlocker.Droid
{

    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged })]
    public class PhonecallReceiver : BroadcastReceiver
    {

        //string manufacturer = Build.Manufacturer;
        //string model = Build.Model;
        //decimal versionRelease = Convert.ToDecimal(Build.VERSION.Release);
        int version = (int)Build.VERSION.SdkInt;
        public override void OnReceive(Context context, Intent intent)
        {
            //var numbersWhiteList = ChecaNumerosWhiteList();

            if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
            {
                var state = intent.GetStringExtra(TelephonyManager.ExtraState);
                var incomingNumber = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);

                var bloquearChamada = NumeroWhiteList(incomingNumber);

                if (bloquearChamada)
                {
                    if (state == TelephonyManager.ExtraStateRinging && version >= 28)
                    {
                        TelecomManager telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);
                        telecomManager.EndCall();
                    }

                    if (state == TelephonyManager.ExtraStateRinging && version <= 27)
                    {
                        var manager = (TelephonyManager)context.GetSystemService(Context.TelephonyService);

                        IntPtr TelephonyManager_getITelephony = JNIEnv.GetMethodID(manager.Class.Handle,
                                                                                   "getITelephony",
                                                                                   "()Lcom/android/internal/telephony/ITelephony;");

                        IntPtr telephony = JNIEnv.CallObjectMethod(manager.Handle, TelephonyManager_getITelephony);
                        IntPtr ITelephony_class = JNIEnv.GetObjectClass(telephony);
                        IntPtr ITelephony_endCall = JNIEnv.GetMethodID(ITelephony_class,
                                                                       "endCall", "()Z");

                        JNIEnv.CallBooleanMethod(telephony, ITelephony_endCall);
                        JNIEnv.DeleteLocalRef(telephony);
                        JNIEnv.DeleteLocalRef(ITelephony_class);
                    }
                }
            }
        }
        public bool NumeroWhiteList(string incomingNumber)
        {
            var dataBase = App.Database.GetNumberAsync();
            var numbersWhiteList = dataBase.Result;

            for (int i = 0; i < numbersWhiteList.Count; i++)
            {
                if (incomingNumber == numbersWhiteList[i].Number) return false;
            }

            return true;
        }
    }
}