using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories.Interfaces;

namespace WebApplication1.Data.Repositories
{
	public class AdminRepository : IAdminRepository
	{
		private readonly MobileShopDataContext _context;
		public AdminRepository(MobileShopDataContext context) {  _context = context; }
		public List<Admin> GetAll()
		{
			return _context.Admins.ToList();
		}
	}
}
