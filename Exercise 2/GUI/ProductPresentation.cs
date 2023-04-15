using Exercise_2.BUS;
using Exercise_2.DAl.NSUnitOfWork;
using Exercise_2.DAl.Repository;

namespace Exercise_2.GUI
{
    public class ProductPresentation
    {
        public void ProductMenu()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UnitOfWork u = new UnitOfWork(context);
            ProductRepository productRepository = new ProductRepository(context);
            ProductBusiness productBusiness = new ProductBusiness(u, productRepository);
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Product Menu: \n");
                Console.WriteLine("1. Add a new product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Update a product");
                Console.WriteLine("4. Delete a product");
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
                            productBusiness.Add();
                            break;
                        case 2:
                            productBusiness.ViewAll();
                            break;
                        case 3:
                            productBusiness.Update();
                            break;
                        case 4:
                            productBusiness.Delete();
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