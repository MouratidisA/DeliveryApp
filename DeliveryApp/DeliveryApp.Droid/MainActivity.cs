using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;

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

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            var email = EmailEditText.Text;
            var password = PasswordEditText.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this,"Email and password cannot be empty",ToastLength.Long).Show();
            }
            else
            {
                var user = (await MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user.Password == password)
                {
                    Toast.MakeText(this, "Login successful", ToastLength.Long).Show();
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
            intent.PutExtra("email",EmailEditText.Text);
            StartActivity(intent);
        }
    }
}