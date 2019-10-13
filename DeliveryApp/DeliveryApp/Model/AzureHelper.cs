using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryApp.Model
{
    public class AzureHelper
    {
        //TODO [Droid] change with correct Azure Mobile App Service URL
        public static MobileServiceClient MobileService = new MobileServiceClient("Mobile App Service URL");
    }
}
