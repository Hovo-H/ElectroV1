using WebApplication1.Data.Entities;
namespace WebApplication1.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetById (int id);
        List<Product> GetAll();
        void Delete(Product product);
        void SaveChanges();
    }
}
