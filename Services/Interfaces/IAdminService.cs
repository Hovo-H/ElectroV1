using WebApplication1.ViewModels.Users;

namespace WebApplication1.Services.Interfaces
{
	public interface IAdminService
	{
		public List<UserViewModel> GetAllAdmins();
		public bool Login(LoginViewModel model);
	}
}
