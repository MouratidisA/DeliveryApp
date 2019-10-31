using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryPersonApp.Android
{
    public class DeliveredFragment : global::Android.Support.V4.App.ListFragment
    {
        private List<Delivery> _deliveries;

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            _deliveries = new List<Delivery>();

            var userId = (Activity as TabsActivity).UserId;
            _deliveries = await Delivery.GetDelivered(userId);
            ListAdapter = new ArrayAdapter(Activity, global::Android.Resource.Layout.SimpleListItem1, _deliveries);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}