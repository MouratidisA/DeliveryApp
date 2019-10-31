using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;


namespace DeliveryPersonApp.Android
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : global::Android.Support.V4.App.FragmentActivity
    {
        private TabLayout _tabLayout;
     


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);

            
            _tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            _tabLayout.TabSelected += TabLayout_TabSelected;

            FragmentNavigate(new DeliveringFragment());
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new DeliveringFragment());
                    break;
                case 1:
                    FragmentNavigate(new WaitingFragment());
                    break;
                case 2:
                    FragmentNavigate(new DeliveredFragment());
                    break;
            }
        }

        private void FragmentNavigate(global::Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}