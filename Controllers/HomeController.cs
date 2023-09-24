using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;
using WebApplication1.Data;
using WebApplication1.Services;
using WebApplication1.ViewModels.Categories;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _service;
		private readonly IProductService _productservice;
		public HomeController(ICategoryService service, IProductService productservice)
        {
			_service = service;
			_productservice = productservice;
        }
		[HttpGet]
		public IActionResult Index()
        {
			var Categories = _service.GetListForDropdown();
			ViewBag.Products = _productservice.GetAllProducts();
			return View(Categories);
        }
    }
}
