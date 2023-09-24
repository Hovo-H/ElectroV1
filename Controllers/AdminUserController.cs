using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly IUserService _userService;
        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _userService.Delete(Id);
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public IActionResult Login()
        {
			return View();
            
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (_userService.Login(model))
            {
                return RedirectToAction("Index","Home");
            }return View();
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var users = _userService.GetAllUsers();
            var model = new UserFilterListViewModel();
            ViewBag.Filter = _userService.Filter(model, users);
            return View();
        }
        [HttpPost]
        public IActionResult UserList(UserFilterListViewModel user)
        {
            var allusers = _userService.GetAllUsers();
            ViewBag.Filter = _userService.Filter(user, allusers);
            return View();
        }
        [HttpGet]
        public IActionResult Register(int? Id)
        {
            UserViewModel model = Id.HasValue ? _userService.GetById(Id.Value) : new UserViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            if (model.Id > 0)
            {
                _userService.Update(model);
            }
            else
            {
                _userService.Add(model);
            }
            return RedirectToAction("Index","Home");
        }
    }
}