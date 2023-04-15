using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;

namespace Exercise_2.DAl.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetails>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}