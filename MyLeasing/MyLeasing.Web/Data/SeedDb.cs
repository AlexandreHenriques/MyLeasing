using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();


            var user = await _userHelper.GetUserByEmailAsync("alex@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Alexandre",
                    LastName = "Henriques",
                    Email = "alex@gmail.com",
                    UserName = "alex@gmail.com",
                    PhoneNumber = "234823543"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if(result!= IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in seeder");
                }
            }

            if(!_context.Owners.Any())
            {
                AddOwner("Ana","Silva","212346513", "962346513", "Rua Albertina", user);
                AddOwner("Paulo", "Borges", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Tiago", "Silva", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Ana", "Malhoa", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Bruno", "Alves", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Zé", "Manel", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Oscar", "Silva", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Maria", "Fernandes", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Mario", "Rui", "212346513", "962346513", "Rua Albertina", user);
                AddOwner("Ruben", "Silva", "212346513", "962346513", "Rua Albertina", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstname, string lastname, string fixo, string mobile, string address, User user)
        {
            _context.Owners.Add(new Entities.Owner
            {
                Document = _random.Next(100000),
                FirstName = firstname,
                LastName = lastname,
                FixedPhone = fixo,
                CellPhone = mobile,
                Address = address,
                User = user
            });
        }
    }
}
