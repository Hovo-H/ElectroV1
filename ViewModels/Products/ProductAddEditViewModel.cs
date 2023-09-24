using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data.Entities;

namespace WebApplication1.ViewModels.Products
{
    public class ProductAddEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }
        public string Color { get; set; }
        public int GbSize { get; set; }
        public int Ram { get; set; }
        public string ImageUrl { get; set; }
    }
}
