using Android.App;
using Android.Content;
using Android.Telecom;
using System;

namespace CallBlocker.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { CallScreeningService.RoleService })]
    public class ScreeningService : CallScreeningService
    {
        Call call;
        public override void OnScreenCall(Call.Details callDetails)
        {
            string phoneNumber = (string)callDetails.GetHandle();

            call.Disconnect();
        }
    }
}