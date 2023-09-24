using WebApplication1.Data.Entities;
namespace WebApplication1.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(int id);
        List<Category> GetAll();
        void Delete(Category category);
        void SaveChanges();
    }
}
