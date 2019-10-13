using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class Delivery
    {
        public string Id { get; set; }

        public static async Task<List<Delivery>> GetDeliveries()
        {
            List<Delivery> deliveriesList = new List<Delivery>();

            deliveriesList = await AzureHelper.MobileService.GetTable<Delivery>().ToListAsync();

            return deliveriesList;
        }
    }
}
