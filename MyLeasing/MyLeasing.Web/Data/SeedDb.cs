using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if(!_context.Owners.Any())
            {
                AddOwner("Ana","Silva","212346513", "962346513", "Rua Albertina");
                AddOwner("Paulo", "Borges", "212346513", "962346513", "Rua Albertina");
                AddOwner("Tiago", "Silva", "212346513", "962346513", "Rua Albertina");
                AddOwner("Ana", "Malhoa", "212346513", "962346513", "Rua Albertina");
                AddOwner("Bruno", "Alves", "212346513", "962346513", "Rua Albertina");
                AddOwner("Zé", "Manel", "212346513", "962346513", "Rua Albertina");
                AddOwner("Oscar", "Silva", "212346513", "962346513", "Rua Albertina");
                AddOwner("Maria", "Fernandes", "212346513", "962346513", "Rua Albertina");
                AddOwner("Mario", "Rui", "212346513", "962346513", "Rua Albertina");
                AddOwner("Ruben", "Silva", "212346513", "962346513", "Rua Albertina");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstname, string lastname, string fixo, string mobile, string address)
        {
            _context.Owners.Add(new Entities.Owner
            {
                Document = _random.Next(100000),
                FirstName = firstname,
                LastName = lastname,
                FixedPhone = fixo,
                CellPhone = mobile,
                Address = address
            });
        }
    }
}
