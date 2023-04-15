using Castle.Components.DictionaryAdapter.Xml;
using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;
using Exercise_2.DAl.NSUnitOfWork;

namespace Exercise_2.BUS
{
    public class OrderBusiness
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productsRepository;

        public OrderBusiness(IOrderRepository orderRepository,
                            IProductRepository productRepository,
                            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _productsRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add()
        {
            try
            {
                int index;
                List<int> productId = _productsRepository.GetAll().Select(x => x.Id).ToList();
                index = new Random().Next(productId.Count);
                Order order = new Order()
                {
                    Detail = new Random().Next(0, 1000),
                    CustomerId = 1,
                    ShippingCompanyId = 2,
                    OrderDetails = new List<OrderDetails>()
                    {
                        new OrderDetails()
                        {
                            ProductId = productId[index],
                        }
                    }
                };
                _unitOfWork.BeginTransaction();
                _orderRepository.Add(order);
                _unitOfWork.SaveChanges();
                Console.WriteLine("Create successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Create failed");
                _unitOfWork.Rollback();
            }
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }
        public void ViewAll()
        {
            foreach (var order in GetAllOrders())
            {
                Console.WriteLine($"Order Id: {order.Id}");
                Console.WriteLine($"Customer Id: {order.CustomerId}");
                Console.WriteLine($"Shipping Company Id: {order.ShippingCompanyId}");
                Console.WriteLine();
            }
        }

        public void Delete()
        {
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                Console.WriteLine("Order not found");
                return;
            }
            try
            {
                _unitOfWork.BeginTransaction();
                _orderRepository.Delete(order);
                _unitOfWork.Commit();
                Console.WriteLine("Delete successfully!!!");

            }catch(Exception)
            {
                _unitOfWork.Rollback();
                Console.WriteLine("Delete fail!!");
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                Console.WriteLine("Order not found");
                return;
            }
            order.Detail = new Random().Next(0, 1000);
            order.CustomerId = 1;
            order.ShippingCompanyId = 2;
            _unitOfWork.SaveChanges();
        }
    }
}