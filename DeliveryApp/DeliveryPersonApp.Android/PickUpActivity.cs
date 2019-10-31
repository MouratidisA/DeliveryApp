using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;
using System;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "PickUpActivity")]
    public class PickUpActivity : Activity, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
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


            _mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.pickUpMapFragment);

            _mapFragment.GetMapAsync(this);
        }

        private async void PickUpButton_Click(object sender, EventArgs e)
        {
            await Delivery.MarkAsPickedUp(_deliveryId, _userId);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(_lat, _lng));
            marker.SetTitle("Pick up here");
            googleMap.AddMarker(marker);

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(_lat, _lng), 12));
        }
    }
}