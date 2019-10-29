using Android.App;
using Android.OS;
using Android.Support.Design.Widget;    
using Android.Support.V4.App;
using Android.Support.V7.Widget;

namespace DeliveryApp.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : FragmentActivity
    {
        private TabLayout _tabLayout;
        private Toolbar _tabsToolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);

            _tabsToolbar = FindViewById<Toolbar>(Resource.Id.tabsToolbar);

            _tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            _tabLayout.TabSelected += TabLayout_TabSelected;

            _tabsToolbar.InflateMenu(Resource.Menu.tabsMenu);
            _tabsToolbar.MenuItemClick += TabsToolbar_MenuItemClick;

            FragmentNavigate(new DeliveriesFragment());
        }

        private void TabsToolbar_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(NewDeliveryActivity));
            }
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new DeliveriesFragment());
                    break;
                case 1:
                    FragmentNavigate(new DeliveredFragment());
                    break;
                case 2:
                    FragmentNavigate(new ProfileFragment());
                    break;
            }
        }

        private void FragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}