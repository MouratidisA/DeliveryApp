using System;
using Android.App;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity
    {
        private Button _saveButton;
        private EditText _packageNameEditText;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            _saveButton = FindViewById<Button>(Resource.Id.saveButton);
            _packageNameEditText = FindViewById<EditText>(Resource.Id.packageEditText);

            _saveButton.Click += SaveButton_Click;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery()
            {
                Name = _packageNameEditText.Text,
                Status = 0
            };

            await Delivery.InsertDelivery(delivery);
        }
    }
}