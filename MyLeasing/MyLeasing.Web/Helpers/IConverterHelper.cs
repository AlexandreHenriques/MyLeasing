using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System.Net.Http.Headers;

namespace MyLeasing.Web.Helpers
{
    public interface IConverterHelper
    {
        Owner toOwner(OwnerViewModel model, string path, bool isNew);

        OwnerViewModel ToOwnerViewModel(Owner owner);

        Lessee toLessee(LesseeViewModel model, string path, bool isNew);

        LesseeViewModel ToLesseeViewModel(Lessee lessee);
    }
}
