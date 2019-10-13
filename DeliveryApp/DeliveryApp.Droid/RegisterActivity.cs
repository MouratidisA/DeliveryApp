using Android.App;
using Android.OS;
using Android.Widget;
using System;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText _emailEditText, _passwordEditText, _confirmPasswordEditText;
        private Button _registerUserButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_register);
            _emailEditText = FindViewById<EditText>(Resource.Id.RegisterEmailEditText);
            _passwordEditText = FindViewById<EditText>(Resource.Id.RegisterPasswordEditText);
            _confirmPasswordEditText = FindViewById<EditText>(Resource.Id.RegisterConfirmPasswordEditText);

            _registerUserButton = FindViewById<Button>(Resource.Id.RegisterUserButton);

            _registerUserButton.Click += RegisterUserButton_Clicked;

            string email = Intent.GetStringExtra("email");
            _emailEditText.Text = email;

        }

        private async void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_passwordEditText.Text))
            {
                if (_passwordEditText.Text == _confirmPasswordEditText.Text)
                {
                    if(await User.Register(_emailEditText.Text,_passwordEditText.Text,_confirmPasswordEditText.Text))
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