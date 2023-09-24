using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Products;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int Add(UserViewModel model)
        {
            var Entity = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                CreatedDate = DateTime.Now,
            };
            _userRepository.Add(Entity);
            return Entity.Id;
        }
        public bool Login(LoginViewModel model)
        {
            var existUser = _userRepository.GetAll().Any(x => (x.UserName == model.UserName ||
                                                               x.Email == model.UserName) &&
                                                               x.Password == model.Password);
            return existUser;
        }
        public List<UserViewModel> Filter(UserFilterListViewModel model, List<UserViewModel> users)
        {
            return users.Where(x => ((model.Name == null) || x.UserName.ToLower().Contains(model.Name.ToLower())) ||
            x.Email.ToLower().Contains(model.Name.ToLower())).ToList();
        }
        public void Delete(int Id)
        {
            var entity = _userRepository.GetById(Id);
            _userRepository.Delete(entity);
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.Select(x => new UserViewModel
            {
                Id = x.Id,  
                UserName = x.UserName,
                Email = x.Email,
                Password = x.Password,
                CreatedDate = x.CreatedDate,
            }).ToList();
        }
        public UserViewModel GetById(int Id)
        {
            var entity = _userRepository.GetById(Id);
            return new UserViewModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                Password= entity.Password,
            };
        }
        public int Update(UserViewModel model)
        {
            var entity = _userRepository.GetById(model.Id);
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.Password = model.Password;
            _userRepository.SaveChanges();
            return entity.Id;
        }
    }
}



































































































































































































































































































































































































































//Hovik Karen Samvel