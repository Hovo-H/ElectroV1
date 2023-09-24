using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Migrations;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels.Categories;
using WebApplication1.ViewModels.Vendors;

namespace WebApplication1.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        List<VendorDropdownViewModel> IVendorService.GetListForDropdown()
        {
            var data = _vendorRepository.GetAll();
            return data.Select(v => new VendorDropdownViewModel
            {
                Id = v.Id,
                Name = v.Name,
            }).ToList();
        }
        public int Add(VendorDropdownViewModel model)
        {
            Vendor vendor = new Vendor()
            {
                Name = model.Name,
                Id = model.Id,
            };
            _vendorRepository.Add(vendor);
            return vendor.Id;
        }
        public void Delete(int Id)
        {
            var entity = _vendorRepository.GetById(Id);
            _vendorRepository.Delete(entity);
        }
        public VendorDropdownViewModel GetById(int Id)
        {
            var entity = _vendorRepository.GetById(Id);
            return new VendorDropdownViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
        public List<VendorDropdownViewModel> Filter(VendorFilterListViewModel model, List<VendorDropdownViewModel> vendors)
        {
            return vendors.Where(x => (model.Name == null) || x.Name.ToLower().Contains(model.Name.ToLower())).ToList();
        }
    }
}
