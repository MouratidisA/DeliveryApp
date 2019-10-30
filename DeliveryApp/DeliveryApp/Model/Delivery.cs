using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class Delivery
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }

        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }

        /// <summary>
        /// 0 = waiting delivery person
        /// 1 = being delivered
        /// 2 = delivered
        /// </summary>
        public int Status { get; set; }

        public static async Task<List<Delivery>> GetDeliveries()
        {
            List<Delivery> deliveriesList = new List<Delivery>();
            deliveriesList = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status != 2).ToListAsync();
            return deliveriesList;
        }
        public static async Task<List<Delivery>> GetDelivered()
        {
            List<Delivery> deliveredList = new List<Delivery>();
            deliveredList = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status == 2).ToListAsync();
            return deliveredList;
        }


        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
            return await AzureHelper.Insert<Delivery>(delivery);
        }


        public override string ToString()
        {
            return $"{Name} - {Status}";
        }
    }
}
