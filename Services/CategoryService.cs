using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Categories;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<CategoryDropdownViewModel> GetListForDropdown()
        {
            var data = _categoryRepository.GetAll();
            return data.Select(c => new CategoryDropdownViewModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }
        public int Add(CategoryDropdownViewModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };
            _categoryRepository.Add(category);
            return category.Id;
        }
        public List<CategoryDropdownViewModel> Filter(CategoryFilterListViewModel model, List<CategoryDropdownViewModel> categories)
        {
            return categories.Where(x => (model.Name == null) || x.Name.ToLower().Contains(model.Name.ToLower())).ToList();
        }
        public void Delete(int Id)
        {
            var entity = _categoryRepository.GetById(Id);
            _categoryRepository.Delete(entity);
        }
        public CategoryDropdownViewModel GetById(int Id)
        {
            var entity = _categoryRepository.GetById(Id);
            return new CategoryDropdownViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
