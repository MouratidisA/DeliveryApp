using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class DeliveryPerson
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public static async Task<string> Login(string email, string password)
        {
            string userId = string.Empty;
            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                userId = string.Empty;
            }

            var deliveryPerson = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
            if (deliveryPerson?.Password == password)
            {
                userId = deliveryPerson.Id;
            }

            return userId;
        }


        public static async Task<bool> Register(string email, string password, string confirmPassword)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(password) && (password == confirmPassword))
            {
                var deliveryPerson = new DeliveryPerson() { Email = email, Password = password };

                await AzureHelper.Insert(deliveryPerson);

                result = true;
            }

            return result;
        }


        public static async Task<DeliveryPerson> GetDeliveryPerson(string id)
        {
            DeliveryPerson person = new DeliveryPerson();

            person = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(dp=>dp.Id==id).ToListAsync()).FirstOrDefault();

            return person;
        }
    }
}
