using Android;
using Android.App;
using Android.App.Roles;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;

namespace CallBlocker.Droid
{
    [Activity(Icon = "@mipmap/icon",
              Theme = "@style/MainTheme",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize |
                                     ConfigChanges.Orientation |
                                     ConfigChanges.UiMode |
                                     ConfigChanges.ScreenLayout |
                                     ConfigChanges.SmallestScreenSize)]
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
                Manifest.Permission.ReadPhoneState, // Requer em Android 6 (Api 23)
                Manifest.Permission.CallPhone, // Requer em Android 6 (Api 23)
                Manifest.Permission.AnswerPhoneCalls, // Requer em Android 9 (Api 28)
                Manifest.Permission.BindScreeningService,
            };

            ActivityCompat.RequestPermissions(this, permissions, 123);

            var roleManager = (RoleManager)GetSystemService(Context.RoleService);
            var intent = roleManager.CreateRequestRoleIntent(RoleManager.RoleCallScreening);
            StartActivityForResult(intent, REQUEST_ID);

        }
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [Android.Runtime.GeneratedEnum] Permission[] grantResults)
        //{
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    if (requestCode == 123 && grantResults.Length > 0 && grantResults[0] == Permission.Granted)
        //    {
        //        //RegisterReceiver(new PhonecallReceiver(), new IntentFilter(TelephonyManager.ActionPhoneStateChanged));
        //    }
        //}

        private const int REQUEST_ID = 1;
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == REQUEST_ID)
            {
                if (resultCode == Result.Ok)
                {
                    // Your app is now the call screening app
                }
                else
                {
                    // Your app is not the call screening app
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}