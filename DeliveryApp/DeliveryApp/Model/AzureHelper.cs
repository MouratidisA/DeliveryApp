using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryApp.Model
{
    public class AzureHelper
    {
        //TODO [Droid] change with correct Azure Mobile App Service URL
        public static MobileServiceClient MobileService = new MobileServiceClient("Mobile App Service URL");

        public static async Task<bool> Insert<T>(T objectToInsert)
        {
            try
            {
                await MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
