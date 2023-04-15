using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;
using Exercise_2.DAl.NSUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2.BUS
{
    public class CustomerBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _repoCustomer;

        public CustomerBusiness(IUnitOfWork unitOfWork, ICustomerRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repoCustomer = repo;
        }
        public List<Customer> Get() => _repoCustomer.GetAll().ToList();
        /// <summary>
        /// return all customers to console and format to table 
        /// </summary>
        public void ViewAll(List<Customer> customers)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10} {4,-10}", "ID", "Name", "Phone", "Wallet", "Active");
            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10} {4,-10}", new string('-', 5), new string('-', 20), new string('-', 15), new string('-', 10), new string('-', 10));
            foreach (Customer customer in customers)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10} {4,-10}", customer.Id, customer.Name, customer.Phone, customer.Wallet.HasValue ? customer.Wallet.Value.ToString() : "", customer.IsActive.HasValue ? customer.IsActive.Value.ToString() : "");
            }
        }

        /// <summary>
        /// Add method auto enter new customer by random number
        /// </summary>
        public void Add()
        {
            Random random = new Random();
            Customer customer = new Customer();
            customer.Name = "Customer " + random.Next(1000);
            customer.Phone = "Phone " + random.Next(1000);
            customer.IsActive = true;
            customer.Wallet = random.Next(100);

            try
            {
                _unitOfWork.BeginTransaction();
                Console.WriteLine(_repoCustomer.GetEntityState(customer)); 
                _repoCustomer.Add(customer);
                Console.WriteLine(_repoCustomer.GetEntityState(customer)); 
                _unitOfWork.Commit();
                Console.WriteLine(_repoCustomer.GetEntityState(customer)); 
            }
            catch (DbUpdateException ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't add " + customer.ToString(), ex);
            }
        }

        /// <summary>
        /// Update method enter the value of id of customer need to update
        /// </summary>
        public void Update()
        {
            Console.WriteLine("Enter id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
            Customer customer = _repoCustomer.GetById(id);

            if (customer == null)
            {
                Console.WriteLine("Customer not found");
                return;
            }

            customer.Name = "Updated Customer " + new Random().Next(1000);
            customer.Phone = "Updated Phone " + new Random().Next(1000);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't update " + customer.ToString(), ex);
            }
        }
        /// <summary>
        /// Delete method enter the value of id of customer need to delete
        /// </summary>
        public void Delete()
        {
            Console.WriteLine("Enter id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
            Customer customer = _repoCustomer.GetById(id);

            if (customer == null)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            try
            {
                _repoCustomer.Delete(id);
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't delete customer with ID " + id.ToString(), ex);
            }
        }
        /// <summary>
        /// demo concurrency conflict handle by optimistic locking
        /// </summary>
        /// <param name="id">the id of customer need to update wallet</param>
        public void ConcurrencyConflict(int id)
        {
            var obj = _repoCustomer.GetById(id);
            try
            {
                obj.Wallet = 100;
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                var entry = ex.Entries.Single();
                var databaseValues = entry.GetDatabaseValues();
                if (databaseValues == null)
                {
                    throw new Exception("The record has been deleted by another user.");
                }
                else
                {
                    entry.Reload();
                    _unitOfWork.SaveChanges();
                }
            }
        }
        public void LoadCustomersWithOrders()
        {
            var customers = _repoCustomer.LoadCustomersWithOrders();
            ViewAll(customers);
        }
    }
}