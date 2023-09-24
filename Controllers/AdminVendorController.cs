using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Categories;
using WebApplication1.ViewModels.Users;
using WebApplication1.ViewModels.Vendors;

namespace WebApplication1.Controllers
{
    public class AdminVendorController : Controller
    {
        private readonly IVendorService _vendorservice;
        public AdminVendorController(IVendorService context)
        {
            _vendorservice = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(VendorDropdownViewModel model)
        {
            _vendorservice.Add(model);
			return RedirectToAction("VendorList");
		}
		[HttpGet]
        public IActionResult Delete(int Id)
        {
            _vendorservice.Delete(Id);
            return RedirectToAction("VendorList");
        }
        [HttpGet]
        public IActionResult Add(int? Id)
        {
            VendorDropdownViewModel model = Id.HasValue ? _vendorservice.GetById(Id.Value) : new VendorDropdownViewModel();
            return View(model);
        }
        [HttpGet]
        public IActionResult VendorList()
        {
            var categories = _vendorservice.GetListForDropdown();
            var model = new VendorFilterListViewModel();
            ViewBag.Filter = _vendorservice.Filter(model, categories);
            return View();
        }
        [HttpPost]
        public IActionResult VendorList(VendorFilterListViewModel model)
        {
            var allvendors = _vendorservice.GetListForDropdown();
            ViewBag.Filter = _vendorservice.Filter(model, allvendors);
            return View();
        }
    }
}
