using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories.Interfaces;

namespace WebApplication1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MobileShopDataContext _context;
        public UserRepository(MobileShopDataContext mobileShopDataContext)
        {
            _context = mobileShopDataContext;
        }
        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
