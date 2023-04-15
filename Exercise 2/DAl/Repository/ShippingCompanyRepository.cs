using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2.DAl.Repository
{
    public class ShippingCompanyRepository : GenericRepository<ShippingCompany>, IShippingCompanyRepository
    {
        public ShippingCompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ShippingCompany LoadRelatedData(int id) => _dbSet.Where(x => x.Id == id)
              .Include(x => x.Orders)
              .FirstOrDefault()!;
    }
}