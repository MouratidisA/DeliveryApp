﻿using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public static async Task<bool> Login(string email, string password)
        {
            bool result = false;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return result;
            }

            var user = (await AzureHelper.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
            if (user?.Password == password)
            {
                result = true;
            }

            return result;
        }


        public static async Task<bool> Register(string email, string password, string confirmPassword)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(password) && (password == confirmPassword))
            {
                var user = new User() { Email = email, Password = password };
                await AzureHelper.MobileService.GetTable<User>().InsertAsync(user);
                result = true;
            }

            return result;
        }


    }
}
