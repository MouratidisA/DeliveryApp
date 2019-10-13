using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using System;

namespace DeliveryApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //TODO [Droid] change with correct Azure Mobile App Service URL
        public static MobileServiceClient MobileService = new MobileServiceClient("Mobile App Service URL");

        private EditText EmailEditText, PasswordEditText;
        private Button SignInButton, RegisterButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            EmailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
            PasswordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText1);

            SignInButton = FindViewById<Button>(Resource.Id.SignInButton);
            RegisterButton = FindViewById<Button>(Resource.Id.RegisterButton);

            SignInButton.Click += SignInButton_Clicked;
            RegisterButton.Click += RegisterButton_Clicked;

        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {

        }
        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email",EmailEditText.Text);
            StartActivity(intent);
        }
    }
}