using Android.OS;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    public class DeliveriesFragment : Android.Support.V4.App.ListFragment
    {
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            var deliveries = await Delivery.GetDeliveries();    

            ListAdapter = new ArrayAdapter(Activity,Android.Resource.Layout.SimpleListItem1,deliveries);
        }

   
    }
}