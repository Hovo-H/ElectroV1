using WebApplication1.Data.Repositories;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Services
{
	public class AdminService: IAdminService
	{
		private readonly IAdminRepository _repository;
		public AdminService(IAdminRepository repository)
		{
			_repository = repository;
		}
		public List<UserViewModel> GetAllAdmins()
		{
			var users = _repository.GetAll();
			return users.Select(x => new UserViewModel
			{
				Id = x.Id,
				UserName = x.UserName,
				Password = x.Password
			}).ToList();
		}

		public bool Login(LoginViewModel model)
		{
			var existUser = _repository.GetAll().Any(x => x.UserName == model.UserName &&
															   x.Password == model.Password);
			return existUser;
		}
	}
}
