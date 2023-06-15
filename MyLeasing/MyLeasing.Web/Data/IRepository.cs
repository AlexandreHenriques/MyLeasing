using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public interface IRepository
    {
        void AddOwner(Owner owner);
        void DeleteOwner(Owner owner);
        Owner GetOwner(int id);
        IEnumerable<Owner> GetOwners();
        bool OwnerExists(int id);
        Task<bool> SaveAllAsync();
        void UpdateOwner(Owner owner);

        void AddLessee(Lessee lessee);
        void DeleteLessee(Lessee lessee);
        Lessee GetLessee(int id);
        IEnumerable<Lessee> GetLessee();
        bool LesseeExists(int id);
        void UpdateLessee(Lessee lessee);
    }
}