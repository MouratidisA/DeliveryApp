using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
 

        private EditText _emailEditText, _passwordEditText;
        private Button _signInButton, _registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _emailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
            _passwordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText1);

            _signInButton = FindViewById<Button>(Resource.Id.SignInButton);
            _registerButton = FindViewById<Button>(Resource.Id.RegisterButton);

            _signInButton.Click += SignInButton_Clicked;
            _registerButton.Click += RegisterButton_Clicked;

        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
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
                    Intent intent= new Intent(this,typeof(TabsActivity));
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Incorrect password", ToastLength.Long).Show();
                }
            }

        }
        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email",_emailEditText.Text);
            StartActivity(intent);
        }
    }
}