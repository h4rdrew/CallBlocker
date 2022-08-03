using Android.Telecom;
using Android.Util;

namespace CallBlocker.Droid
{
    //[IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged })]
    public class MyCallService : CallScreeningService
    {
        // https://developer.android.com/reference/android/telecom/CallScreeningService
        // Talvez precise solicitar acesso via UI
        //  https://developer.android.com/reference/android/telecom/CallScreeningService#becoming-the-callscreeningservice

        public override void OnScreenCall(Call.Details callDetails)
        {
            Log.Info("Phone number", callDetails.GetHandle().ToString());

            if (callDetails.CallDirection != CallDirection.Incoming)
            {
                return;
            }

            CallResponse.Builder response = new CallResponse.Builder();

            response.SetDisallowCall(false);
            response.SetRejectCall(false);
            response.SetSilenceCall(false);
            response.SetSkipCallLog(false);
            response.SetSkipNotification(false);

            callDetails.GetHandle();
            RespondToCall(callDetails, response.Build());
        }
    }
}