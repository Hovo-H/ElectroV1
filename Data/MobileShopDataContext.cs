using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;
using WebApplication1.Data;

namespace WebApplication1
{
    public class MobileShopDataContext : DbContext
    {
        public MobileShopDataContext(DbContextOptions<MobileShopDataContext> opt) : base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}