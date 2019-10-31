using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;
using System;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "DeliverActivity")]
    public class DeliverActivity : Activity, IOnMapReadyCallback
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

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(_lat, _lng));
            marker.SetTitle("Deliver here");
            googleMap.AddMarker(marker);
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(_lat, _lng), 12));
        }

    }
}