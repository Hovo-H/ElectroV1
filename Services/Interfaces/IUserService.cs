using WebApplication1.ViewModels.Products;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Services.Interfaces
{
    public interface IUserService
    {
        public int Add(UserViewModel model);
        public void Delete(int Id);
        public int Update(UserViewModel model);
        public UserViewModel GetById(int Id);
        public List<UserViewModel> GetAllUsers();
        public bool Login(LoginViewModel model);
        public List<UserViewModel> Filter(UserFilterListViewModel model, List<UserViewModel> users);
    }
}