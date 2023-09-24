using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using WebApplication1.Data;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Migrations;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Products;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int Add(ProductAddEditViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
                VendorId = model.VendorId,
                Description = model.Description,
                GbSize = model.GbSize,
                Ram = model.Ram,
                ImageUrl = model.ImageUrl,
                Color = model.Color
            };
            _productRepository.Add(product);
            return product.Id;
        }

        public void Delete(int Id)
        {
            var entity = _productRepository.GetById(Id);
            _productRepository.Delete(entity);
        }

        public List<ProductAddEditViewModel> Filter(ProductFilterListViewModel Model)
        {
			var products = GetAllProducts();
            foreach (var product in products)
            {
                product.Price = (product.Price);
			}
                       return products.Where(x => 
                        ((Model.Name == null) || x.Name.ToLower().Contains(Model.Name.ToLower())) &&
                        ((Model.Color == null) || x.Color.ToLower().Contains(Model.Color.ToLower())) &&
                        ((Model.FromPrice == 0) || x.Price >= Model.FromPrice) &&
                        ((Model.GbSize == 0) || x.GbSize >= Model.GbSize) &&
                        ((Model.Ram == 0) || x.Ram >= Model.Ram) &&
                        ((Model.CategoryId == 0) || x.CategoryId == Model.CategoryId) &&
                        ((Model.VendorId == 0) || x.VendorId == Model.VendorId) &&
                        ((Model.ToPrice == 0) || x.Price <= Model.ToPrice)).ToList();
        }

        public List<ProductAddEditViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products.Select(x => new ProductAddEditViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CategoryId = x.CategoryId,
                VendorId = x.VendorId,
                Description = x.Description,
                GbSize = x.GbSize,
                Ram = x.Ram,
                ImageUrl = x.ImageUrl,
                Color = x.Color
            }).ToList();
        }

        public ProductAddEditViewModel GetById(int Id)
        {
            var entity = _productRepository.GetById(Id);
            return new ProductAddEditViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                GbSize = entity.GbSize,
                Description = entity.Description,
                Ram = entity.Ram,
                CategoryId = entity.CategoryId,
                VendorId = entity.VendorId
            };
        }

        public ProductAddEditViewModel GetById(int Id, string? Promocode)
        {
            var entity = _productRepository.GetById(Id);
            if (Promocode == "Serg20")
            {
                return new ProductAddEditViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Color = entity.Color,
                    Price = (int)(entity.Price * 0.8),
                    ImageUrl = entity.ImageUrl,
                    GbSize = entity.GbSize,
                    Description = entity.Description,
                    Ram = entity.Ram,
                    CategoryId = entity.CategoryId,
                    VendorId = entity.VendorId
                };
            }
            else
            {
                return GetById(Id);
            }
        }

		public int Update(ProductAddEditViewModel model)
        {
            var entity = _productRepository.GetById(model.Id);
            entity.Name = model.Name;
            entity.Color = model.Color;
            entity.CategoryId = model.CategoryId;
            entity.VendorId = model.VendorId;
            entity.GbSize = model.GbSize;
            entity.Ram = model.Ram;
            entity.ImageUrl = model.ImageUrl;
            return entity.Id;
        }
    }
}
