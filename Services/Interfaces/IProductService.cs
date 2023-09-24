using WebApplication1.ViewModels.Products;

namespace WebApplication1.Services.Interfaces
{
    public interface IProductService
    {
        public int Add(ProductAddEditViewModel model);
        public void Delete(int Id);
        public int Update(ProductAddEditViewModel model);
        public ProductAddEditViewModel GetById(int Id);
		public ProductAddEditViewModel GetById(int Id,string Promocode);
		public List<ProductAddEditViewModel> GetAllProducts();
        public List<ProductAddEditViewModel> Filter(ProductFilterListViewModel model);
	}
}
