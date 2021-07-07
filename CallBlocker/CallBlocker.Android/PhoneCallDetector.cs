using Android.Content;
using Android.Telephony;

namespace CallBlocker.Droid
{
    public class PhoneCallDetector : PhoneStateListener
    {
        //private Intent intent;
        public Android.Telecom.Call call;

        public override void OnCallStateChanged(CallState state, string incomingNumber)
        {
            base.OnCallStateChanged(state, incomingNumber);
            
            if (state == CallState.Ringing)
            {
                var number = incomingNumber;
            }
        }
    }
}