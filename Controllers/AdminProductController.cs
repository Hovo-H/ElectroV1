using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services;
using WebApplication1.ViewModels.Products;

namespace WebApplication2.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IVendorService _vendorService;
        public AdminProductController(
            IProductService productService,
            ICategoryService categoryService,
            IVendorService vendorService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _vendorService = vendorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult list()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProductList()
        {
			ViewBag.Categories = _categoryService.GetListForDropdown();
			ViewBag.Vendors = _vendorService.GetListForDropdown();
			var model = new ProductFilterListViewModel();
            ViewBag.Filter = _productService.Filter(model);
            return View();
        }
        [HttpPost]
        public IActionResult ProductList(ProductFilterListViewModel model)
        {
			ViewBag.Categories = _categoryService.GetListForDropdown();
			ViewBag.Vendors = _vendorService.GetListForDropdown();
			ViewBag.Filter = _productService.Filter(model);
            return View();
        }
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            ViewBag.Categories = _categoryService.GetListForDropdown();
            ViewBag.Vendors = _vendorService.GetListForDropdown();
            ProductAddEditViewModel model = id.HasValue ?
                _productService.GetById(id.Value) :
                new ProductAddEditViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(ProductAddEditViewModel model)
        {
            ViewBag.Categories = _categoryService.GetListForDropdown();
            ViewBag.Vendors = _vendorService.GetListForDropdown();
            if (model.Id > 0)
            {
                _productService.Update(model);
            }
            else
            {
                _productService.Add(model);
            }
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _productService.Delete(Id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
		public IActionResult Product(int Id,string Name)
		{
			ViewBag.Product = _productService.GetById(Id, Name);
			return View();
		}
	}
}
