using Exercise_2.BUS;
using Exercise_2.DAl.NSUnitOfWork;
using Exercise_2.DAl.Repository;

namespace Exercise_2.GUI
{
    public class CustomerPresentation
    {
        public void CustomerMenu()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UnitOfWork u = new UnitOfWork(context);
            CustomerRepository customerRepository = new CustomerRepository(context);
            CustomerBusiness customerBusiness = new CustomerBusiness(u, customerRepository);
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Customer Menu: \n");
                Console.WriteLine("1. Add a new customer");
                Console.WriteLine("2. View all customers");
                Console.WriteLine("3. Update a customer");
                Console.WriteLine("4. Delete a customer");
                Console.WriteLine("5. CustomersWithOrders");
                Console.WriteLine("6. Back to main menu");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int option = 0;
                while (option < 1 || option > 5)
                {
                    System.Console.WriteLine("Enter your choice...");
                    if (!int.TryParse(Console.ReadLine(), out option))
                        System.Console.WriteLine("Invalid input!!");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    switch (option)
                    {
                        case 1:
                            customerBusiness.Add();
                            break;
                        case 2:
                            customerBusiness.ViewAll(customerBusiness.Get());
                            break;
                        case 3:
                            customerBusiness.Update();
                            break;
                        case 4:
                            customerBusiness.Delete();
                            break; 
                        case 5:
                            customerBusiness.LoadCustomersWithOrders();
                            break;
                        case 6:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}