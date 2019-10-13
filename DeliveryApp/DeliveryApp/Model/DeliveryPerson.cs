using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class DeliveryPerson
    {
        public string Id { get; set; }

        public static async Task<DeliveryPerson> GetDeliveryPerson(string id)
        {
            DeliveryPerson person = new DeliveryPerson();

            person = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(dp=>dp.Id==id).ToListAsync()).FirstOrDefault();

            return person;
        }
    }
}
