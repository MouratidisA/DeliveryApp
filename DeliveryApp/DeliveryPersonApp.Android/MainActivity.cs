using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using Android.Content;
using DeliveryApp.Model;

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

        private async void SignInButton_Click(object sender, EventArgs e)
        {

            var email = _emailEditText.Text;
            var password = _passwordEditText.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Email and password cannot be empty", ToastLength.Long).Show();
            }
            else
            {
                var userId = await DeliveryPerson.Login(email, password);
                
                if (!string.IsNullOrEmpty(userId))
                {
                    Toast.MakeText(this, "Login successful", ToastLength.Long).Show();
                    Intent intent = new Intent(this,typeof(TabsActivity));
                    intent.PutExtra("userId",userId);                    
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
}