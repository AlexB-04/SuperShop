using System;
using System.Threading.Tasks;
using System.Linq;
using SuperShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using SuperShop.Helpers;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("rafaasf@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Rafael",
                    LastName = "Sanchez",
                    Email = "rafaasf@gmail.com",
                    UserName = "rafaasfs@gmail.com",
                    PhoneNumber = "212343555"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidCastException("Could not create the user in seeder");
                }
            }

            if (!_context.Products.Any())
            {
                AddProduct("Iphone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("IWatch Series 4", user);
                AddProduct("IPad Mini", user);

                await _context.SaveChangesAsync();
            }
        }
        
        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Entities.Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
