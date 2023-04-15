using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2.DAl.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Order LoadRelatedData(int id) => _dbSet.Where(x => x.Id == id)
                .Include(x => x.OrderDetails)
                .FirstOrDefault()!;
    }
}