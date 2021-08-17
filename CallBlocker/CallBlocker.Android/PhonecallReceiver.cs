using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
        public void CallTeste(Call call)
        {
            call.Reject(false, "teste");
        }
        public override void OnReceive(Context context, Intent intent)
        {

            if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
            {
                var state = intent.GetStringExtra(TelephonyManager.ExtraState);
                var number = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);

                if (state == TelephonyManager.ExtraStateRinging && versionRelease >= 9 && number != null)
                {
                    TelecomManager telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);
                    telecomManager.EndCall();

                }

                if (state == TelephonyManager.ExtraStateRinging && versionRelease < 9)
                {
                    var manager = (TelephonyManager)context.GetSystemService(Context.TelephonyService);

                    IntPtr TelephonyManager_getITelephony = JNIEnv.GetMethodID(
                            manager.Class.Handle,
                            "getITelephony",
                            "()Lcom/android/internal/telephony/ITelephony;");

                    IntPtr telephony = JNIEnv.CallObjectMethod(manager.Handle, TelephonyManager_getITelephony);
                    IntPtr ITelephony_class = JNIEnv.GetObjectClass(telephony);
                    IntPtr ITelephony_endCall = JNIEnv.GetMethodID(
                            ITelephony_class,
                            "endCall",
                            "()Z");
                    JNIEnv.CallBooleanMethod(telephony, ITelephony_endCall);
                    JNIEnv.DeleteLocalRef(telephony);
                    JNIEnv.DeleteLocalRef(ITelephony_class);
                }
            }
        }
    }
}