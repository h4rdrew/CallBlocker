using Android.App;
using Android.App.Roles;
using Android.Telecom;
using Android.Util;

namespace com.h4rdrewstudios.h4rdblocker
{
    [IntentFilter(new[] { RoleManager.RoleCallScreening })]
    public class CallScreeningService : Android.Telecom.CallScreeningService
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

            response.SetSilenceCall(false);
            response.SetSkipCallLog(false);
            response.SetSkipNotification(false);

            var uriFuckThisShit = callDetails.GetHandle();

            if (uriFuckThisShit.ToString().Contains("123"))
            {
                response.SetRejectCall(true);
                response.SetDisallowCall(true);
            }
            else
            {
                response.SetDisallowCall(false);
                response.SetRejectCall(false);
            }

            RespondToCall(callDetails, response.Build());
        }
    }
}