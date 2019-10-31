using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText _emailEditText, _passwordEditText;
        private Button _signinButton, _registerButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            _passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            _signinButton = FindViewById<Button>(Resource.Id.signinButton);
            _registerButton = FindViewById<Button>(Resource.Id.registerButton);

            _signinButton.Click += SignInButton_Click;
            _registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));            
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            var email = _emailEditText.Text;
            var password = _passwordEditText.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Email and password cannot be empty", ToastLength.Long).Show();
            }
            else
            {
                //var result = await User.Login(email, password); TODO uncomment when Azure Service is available 
                var result = true;

                if (result)
                {
                    Toast.MakeText(this, "Login successful", ToastLength.Long).Show();
                    StartActivity(typeof(TabsActivity));
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Incorrect password", ToastLength.Long).Show();
                }
            }
         
        }
    }
}