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

        public async override void OnScreenCall(Call.Details callDetails)
        {
            Log.Info("Phone number", callDetails.GetHandle().ToString());

            if (callDetails.CallDirection != CallDirection.Incoming)
            {
                return;
            }

            CallResponse.Builder response = new CallResponse.Builder();

            response.SetSilenceCall(false)
                    .SetSkipCallLog(false)
                    .SetSkipNotification(false);

            var callUri = callDetails.GetHandle();
            // "(650) 555-0123"
            // => "tel:6505550123"

            var permite = await CallBlocker.Droid.NumberManager.NumeroPresenteWhiteListAsync(callUri.EncodedSchemeSpecificPart);

            if (permite) // block numbers with "123"
            {
                response.SetDisallowCall(false);
                response.SetRejectCall(false);
            }
            else
            {
                response.SetRejectCall(true);
                response.SetDisallowCall(true);
            }

            RespondToCall(callDetails, response.Build());
        }
    }
}