using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Data;

namespace WebApplication1.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MobileShopDataContext _context;
        public CategoryRepository(MobileShopDataContext context)
        {
            _context = context;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
