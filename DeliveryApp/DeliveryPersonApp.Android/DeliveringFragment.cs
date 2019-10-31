using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using DeliveryApp.Model;
using System.Collections.Generic;

namespace DeliveryPersonApp.Android
{
    public class DeliveringFragment : global::Android.Support.V4.App.ListFragment
    {
        private List<Delivery> _deliveries;

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            _deliveries = new List<Delivery>();

            var userId = (Activity as TabsActivity).UserId;
            _deliveries = await Delivery.GetBeingDelivered(userId);
            ListAdapter = new ArrayAdapter(Activity, global::Android.Resource.Layout.SimpleListItem1, _deliveries);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var selectedDelivery = _deliveries[position];

            Intent intent = new Intent(Activity, typeof(DeliverActivity));
            intent.PutExtra("latitude", selectedDelivery.DestinationLatitude);
            intent.PutExtra("longitude", selectedDelivery.DestinationLongitude);
            intent.PutExtra("deliveryId", selectedDelivery.Id);

            StartActivity(intent);
        }
    }
}