using System;
using Android.App;
using Android.Gms.Maps;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "DeliverActivity")]
    public class DeliverActivity : Activity
    {
        private MapFragment _mapFragment;
        private Button _deliverButton;

        private double _lat, _lng;
        private string _deliveryId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Deliver);

            _mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.deliverMapFragment);

            _deliverButton = FindViewById<Button>(Resource.Id.deliverButton);
            _deliverButton.Click += DeliverButton_Click;


            _lat = Intent.GetDoubleExtra("latitude", 0);
            _lng = Intent.GetDoubleExtra("latitude", 0);
            _deliveryId = Intent.GetStringExtra("deliveryId");

        }

        private async void DeliverButton_Click(object sender, EventArgs e)
        {
            await Delivery.MarkAsDelivered(_deliveryId);
        }
    }
}