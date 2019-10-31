using Android.App;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;
using System;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "PickUpActivity")]
    public class PickUpActivity : Activity
    {
        private Button _pickUpButton;
        private double _lat, _lng;
        private string _userId, _deliveryId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PickUp);


            _pickUpButton = FindViewById<Button>(Resource.Id.pickUpButton);
            _pickUpButton.Click += PickUpButton_Click;


            _lat = Intent.GetDoubleExtra("latitude", 0);
            _lng = Intent.GetDoubleExtra("latitude", 0);
            _deliveryId = Intent.GetStringExtra("deliveryId");
            _userId = Intent.GetStringExtra("userId");
        }

        private async void PickUpButton_Click(object sender, EventArgs e)
        {
            await Delivery.MarkAsPickedUp(_deliveryId, _userId);
        }
    }
}