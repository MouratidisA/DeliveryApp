using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;
using System;


namespace DeliveryApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        private Button _saveButton;
        private EditText _packageNameEditText;
        private MapFragment _mapFragment, _destinationMapFragment;

        private double _latitude, _longitude;
        private LocationManager _locationManager;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            _saveButton = FindViewById<Button>(Resource.Id.saveButton);
            _packageNameEditText = FindViewById<EditText>(Resource.Id.packageEditText);
            _mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFragment);
            _destinationMapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.destinationMapFragment);


            _saveButton.Click += SaveButton_Click;



        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            //TODO implement location retrieval from _mapFragment and _destinationFragment 
            //var originLocation = _mapFragment.Map.CameraPosition.Target;
            //var destinationLocation = _destinationMapFragment.Map.CameraPosition.Target;

            //TODO replace current location with fragments' location
            var currentLocation = _locationManager.GetLastKnownLocation(LocationManager.NetworkProvider);
            var originLocation = currentLocation;
            var destinationLocation = currentLocation;

            Delivery delivery = new Delivery()
            {
                Name = _packageNameEditText.Text,
                Status = 0,

                OriginLatitude = originLocation.Latitude,
                OriginLongitude = originLocation.Longitude,

                DestinationLatitude = destinationLocation.Latitude,
                DestinationLongitude = destinationLocation.Longitude
            };

            await Delivery.InsertDelivery(delivery);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(_latitude, _longitude));
            marker.SetTitle("Your Location");
            googleMap.AddMarker(marker);
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(_latitude, _longitude), 10));

        }

        public void OnLocationChanged(Location location)
        {
            _latitude = location.Latitude;
            _longitude = location.Longitude;
            _mapFragment.GetMapAsync(this);
            _destinationMapFragment.GetMapAsync(this);
        }

        public void OnProviderDisabled(string provider)
        {
         
        }

        public void OnProviderEnabled(string provider)
        {
         
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
         
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }


        protected override void OnResume()
        {
            base.OnResume();

            _locationManager = GetSystemService(Context.LocationService) as LocationManager;
            string provider = LocationManager.GpsProvider;

            if (_locationManager.IsProviderEnabled(provider))
            {
                _locationManager.RequestLocationUpdates(provider, 5000, 10, this);
            }

            var location = _locationManager.GetLastKnownLocation(LocationManager.NetworkProvider);
            _latitude = location.Latitude;
            _longitude = location.Longitude;
            _mapFragment.GetMapAsync(this);
            _destinationMapFragment.GetMapAsync(this);
        }
    }
}