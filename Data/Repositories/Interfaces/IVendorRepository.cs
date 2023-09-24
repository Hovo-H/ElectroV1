using WebApplication1.Data.Entities;

namespace WebApplication1.Data.Repositories.Interfaces
{
    public interface IVendorRepository
    {
        void Add(Vendor vendor);
        Vendor GetById(int id);
        List<Vendor> GetAll();
        void Delete(Vendor vendor);
        void SaveChanges();
    }
}
