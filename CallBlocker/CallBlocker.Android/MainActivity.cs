using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using AndroidX.Core.App;

namespace CallBlocker.Droid
{
    [Activity(Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var permissions = new string[]
        {
                Manifest.Permission.ReadPhoneState,
                Manifest.Permission.CallPhone,
                Manifest.Permission.ModifyPhoneState,
                Manifest.Permission.AnswerPhoneCalls,
                Manifest.Permission.BindScreeningService,
                Manifest.Permission.BindTelecomConnectionService,
                Manifest.Permission.ReadCallLog,
                
        };

            ActivityCompat.RequestPermissions(this, permissions, 123);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == 123 && grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                RegisterReceiver(new PhonecallReceiver(), new IntentFilter(TelephonyManager.ActionPhoneStateChanged));
            }
        }
    }
}