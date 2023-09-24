using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels.Users;
using WebApplication1.Data;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;
		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}
		[HttpGet]
		public IActionResult AdminLogin()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AdminLogin(LoginViewModel model)
		{
			if (_adminService.Login(model))
			{
				return RedirectToAction("UserList", "AdminUser");
			}
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
