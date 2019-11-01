using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Support.V4.Content;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Support.V7.App;
using Android.Widget;
using DeliveryApp.Model;
using System;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,Name = "DeliveryPersonApp.Android.DeliveryPersonApp.Android.MainActivity",Exported = true)]
    [MetaData("android.app.shortcuts",Resource = "@xml/shortcuts")]
    public class MainActivity : AppCompatActivity
    {
        private EditText _emailEditText, _passwordEditText;
        private Button _signinButton, _registerButton;
        private FingerprintManagerCompat _fingerprintManagerCompat;
        private global::Android.Support.V4.OS.CancellationSignal _cancelation;
        private ISharedPreferences _sharedPreferences;
        private string _userId;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _fingerprintManagerCompat = FingerprintManagerCompat.From(this);
            _cancelation = new global::Android.Support.V4.OS.CancellationSignal();
            _sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            //TODO rest shared Preferences: Application.Context.GetSharedPreferences("sampleSharedPreferencesName",FileCreationMode.Private);


            SetContentView(Resource.Layout.Main);

            _emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            _passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            _signinButton = FindViewById<Button>(Resource.Id.signinButton);
            _registerButton = FindViewById<Button>(Resource.Id.registerButton);

            _signinButton.Click += SignInButton_Click;
            _registerButton.Click += RegisterButton_Click;


            //Register from Shortcut options
            if (!string.IsNullOrEmpty(Intent?.Data?.LastPathSegment))
            {
                if (Intent.Data.LastPathSegment == "register")
                {
                    StartActivity(typeof(RegisterActivity));
                }
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            var canUseFingerprint = CanUseFingerprint();

            if (canUseFingerprint)
            {
                LogUserIn();
            }
            else
            {
                var email = _emailEditText.Text;
                var password = _passwordEditText.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    Toast.MakeText(this, "Email and password cannot be empty", ToastLength.Long).Show();
                }
                else
                {
                    _userId = await DeliveryPerson.Login(email, password);

                    if (!string.IsNullOrEmpty(_userId))
                    {

                        var preferencesEditor = _sharedPreferences.Edit();
                        preferencesEditor.PutString("userId", _userId);
                        preferencesEditor.Apply();


                        Toast.MakeText(this, "Login successful", ToastLength.Long).Show();
                        Intent intent = new Intent(this, typeof(TabsActivity));
                        intent.PutExtra("userId", _userId);
                        StartActivity(intent);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Incorrect password", ToastLength.Long).Show();
                    }
                }
            }

        }

        private bool CanUseFingerprint()
        {
            _userId = _sharedPreferences.GetString("userId", String.Empty);

            if (!String.IsNullOrEmpty(_userId))
            {

                if (_fingerprintManagerCompat.IsHardwareDetected)
                {
                    if (_fingerprintManagerCompat.HasEnrolledFingerprints)
                    {
                        var permissionResult = ContextCompat.CheckSelfPermission(this, Manifest.Permission.UseFingerprint);
                        if (permissionResult == global::Android.Content.PM.Permission.Granted)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void LogUserIn()
        {
            _cancelation = new global::Android.Support.V4.OS.CancellationSignal();
            FingerprintManagerCompat.AuthenticationCallback authenticationCallback = new AuthenticationCallback(this, _userId);
            Toast.MakeText(this, "Place fingerprint on sensor", ToastLength.Long).Show();
            _fingerprintManagerCompat.Authenticate(null, 0, _cancelation, authenticationCallback, null);
        }
    }


}