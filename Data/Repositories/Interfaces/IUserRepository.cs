using WebApplication1.Data.Entities;

namespace WebApplication1.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        List<User> GetAll();
        void Delete(User user);
        void SaveChanges();
    }
}
