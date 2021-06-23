using Android.Content;
using Android.Telephony;

namespace CallBlocker.Droid
{
    public class PhoneCallDetector : PhoneStateListener
    {
        //private Intent intent;
        private Android.Telecom.Call call;

        public override void OnCallStateChanged(CallState state, string incomingNumber)
        {
            base.OnCallStateChanged(state, incomingNumber);

            if (state == CallState.Ringing)
            {
                call.Disconnect();
                //var number = incomingNumber;
                //var teste = new PhoneCallService();
                //teste.test(number);
                // TODO check number for known contact...
            }
        }
    }
}