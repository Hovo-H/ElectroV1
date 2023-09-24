using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories.Interfaces;

namespace WebApplication1.Data.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly MobileShopDataContext _context;
        public VendorRepository(MobileShopDataContext context)
        {
            _context = context;
        }
        public List<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }
        public void Add(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
        }

        public void Delete(Vendor vendor)
        {
            _context.Vendors.Remove(vendor);
            _context.SaveChanges();
        }
        public Vendor GetById(int id)
        {
            return _context.Vendors.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
