using Android.OS;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    public class DeliveredFragment : Android.Support.V4.App.ListFragment
    {
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
            var delivered = await Delivery.GetDelivered();
            ListAdapter = new DeliveryAdapter(Activity, delivered);
        }
       
    }
}