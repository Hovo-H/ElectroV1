using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Categories;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public AdminCategoryController(ICategoryService service)
        {
            _categoryService = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _categoryService.Delete(Id);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult Add(int? Id)
        {
            CategoryDropdownViewModel model = Id.HasValue ? _categoryService.GetById(Id.Value) : new CategoryDropdownViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(CategoryDropdownViewModel model)
        {
            _categoryService.Add(model);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetListForDropdown();
            var model = new CategoryFilterListViewModel();
            ViewBag.Filter = _categoryService.Filter(model, categories);
            return View();
        }
        [HttpPost]
        public IActionResult CategoryList(CategoryFilterListViewModel model)
        {
            var allcategories = _categoryService.GetListForDropdown();
            ViewBag.Filter = _categoryService.Filter(model, allcategories);
            return View();
        }
    }
}