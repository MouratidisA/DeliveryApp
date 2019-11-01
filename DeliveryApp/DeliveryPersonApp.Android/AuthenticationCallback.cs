using Android.App;
using Android.Content;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Widget;

namespace DeliveryPersonApp.Android
{
    internal class AuthenticationCallback : FingerprintManagerCompat.AuthenticationCallback
    {
        private Activity _activity;
        private string _userId;

        public AuthenticationCallback(Activity activity, string userId)
        {
            _activity = activity;
            _userId = userId;
        }

        public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
        {
            base.OnAuthenticationSucceeded(result);

            Toast.MakeText(_activity, "Login successful", ToastLength.Long).Show();
            Intent intent = new Intent(_activity, typeof(TabsActivity));
            intent.PutExtra("userId", _userId);
            _activity.StartActivity(intent);
        }


        public override void OnAuthenticationFailed()
        {
            base.OnAuthenticationFailed();

            Toast.MakeText(_activity, "Failure", ToastLength.Long).Show();
        }
    }
}