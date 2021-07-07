using Android.App;
using Android.Content;
using Android.OS;
using Android.Telecom;
using Android.Telephony;
using System;

namespace CallBlocker.Droid
{
    [Service]
    public class PhoneCallService : Service
    {
        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            base.OnStartCommand(intent, flags, startId);

            var callDetector = new PhoneCallDetector();
            var tm = (TelephonyManager)base.GetSystemService(TelephonyService);
            tm.Listen(callDetector, PhoneStateListenerFlags.CallState);

            return StartCommandResult.Sticky;
        }
    }
}