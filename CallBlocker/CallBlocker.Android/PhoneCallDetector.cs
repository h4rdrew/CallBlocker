using Android.Telephony;

namespace CallBlocker.Droid
{
    public class PhoneCallDetector : PhoneStateListener
    {
        public override void OnCallStateChanged(CallState state, string incomingNumber)
        {
            base.OnCallStateChanged(state, incomingNumber);

            if (state == CallState.Ringing)
            {
                var number = incomingNumber;
                // TODO check number for known contact...
            }
        }
    }
}