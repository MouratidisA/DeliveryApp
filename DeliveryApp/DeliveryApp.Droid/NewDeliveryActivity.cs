using System;
using Android.App;
using Android.Gms.Maps;
using Android.OS;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity, IOnMapReadyCallback
    {
        private Button _saveButton;
        private EditText _packageNameEditText;
        private MapFragment _mapFragment;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            _saveButton = FindViewById<Button>(Resource.Id.saveButton);
            _packageNameEditText = FindViewById<EditText>(Resource.Id.packageEditText);
            _mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFragment);
            _mapFragment.GetMapAsync(this);


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

        public void OnMapReady(GoogleMap googleMap)
        {

        }
    }
}