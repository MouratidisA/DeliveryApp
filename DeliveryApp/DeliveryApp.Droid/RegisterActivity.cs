using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace DeliveryApp.Droid
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText EmailEditText, PasswordEditText, ConfirmPasswordEditText;
        private Button RegisterUserButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_register);
            EmailEditText = FindViewById<EditText>(Resource.Id.RegisterEmailEditText);
            PasswordEditText = FindViewById<EditText>(Resource.Id.RegisterPasswordEditText);
            ConfirmPasswordEditText = FindViewById<EditText>(Resource.Id.RegisterConfirmPasswordEditText);

            RegisterUserButton = FindViewById<Button>(Resource.Id.RegisterUserButton);

            RegisterUserButton.Click += RegisterUserButton_Clicked;

        }

        private void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}