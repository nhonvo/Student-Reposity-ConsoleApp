using Exercise_2.BUS;
using Exercise_2.DAl.Interface;
using Exercise_2.DAl.NSUnitOfWork;
using Exercise_2.DAl.Repository;

namespace Exercise_2.GUI
{
    public class OrderPresentation
    {
        public void OrderMenu()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UnitOfWork u = new UnitOfWork(context);
            OrderRepository o = new OrderRepository(context);
            IProductRepository p = new ProductRepository(context);
            OrderBusiness orderBusiness = new OrderBusiness(o, p, u);
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Order Menu: \n");
                Console.WriteLine("1. Add a new order");
                Console.WriteLine("2. View all orders");
                Console.WriteLine("3. Update a order");
                Console.WriteLine("4. Delete a order");
                Console.WriteLine("5. Back to main menu");
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
                            orderBusiness.Add();
                            break;
                        case 2:
                            orderBusiness.ViewAll();
                            break;
                        case 3:
                            orderBusiness.Update();
                            break;
                        case 4:
                            orderBusiness.Delete();
                            break;
                        case 5:
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