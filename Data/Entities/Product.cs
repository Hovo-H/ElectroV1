using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WebApplication1.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public string Color { get; set; }
        public int GbSize { get; set; }
        public int Ram { get; set; }
        public string ImageUrl { get; set; }
    }
}
