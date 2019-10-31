using Android.App;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;
using System;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText _emailEditText, _passwordEditText, _confirmPasswordEditText;
        private Button _registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);
            
            _emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            _passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            _confirmPasswordEditText = FindViewById<EditText>(Resource.Id.registerConfirmPasswordEditText);            
            _registerButton = FindViewById<Button>(Resource.Id.registerButton);
            
            _registerButton.Click += RegisterButton_Click;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_passwordEditText.Text))
            {
                if (_passwordEditText.Text == _confirmPasswordEditText.Text)
                {
                    if (await User.Register(_emailEditText.Text, _passwordEditText.Text, _confirmPasswordEditText.Text))
                        Toast.MakeText(this, "Success", ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "Try again", ToastLength.Long).Show();
                }
                else
                    Toast.MakeText(this, "Passwords don't match", ToastLength.Long).Show();
            }
            else
                Toast.MakeText(this, "Password cannot be empty", ToastLength.Long).Show();
        }
    }
}