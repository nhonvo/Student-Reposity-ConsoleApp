using Exercise_2.BUS;
using Exercise_2.DAl.NSUnitOfWork;
using Exercise_2.DAl.Repository;

namespace Exercise_2.GUI
{
    public class ShippingCompanyPresentation
    {
        public void ShippingCompanyMenu()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UnitOfWork u = new UnitOfWork(context);
            ShippingCompanyRepository shippingCompanyRepository = new ShippingCompanyRepository(context);
            ShippingCompanyBusiness shippingCompanyBusiness = new ShippingCompanyBusiness(u, shippingCompanyRepository);
            bool back = false;
            while (!back)
            {
                Console.WriteLine("ShippingCompany Menu: \n");
                Console.WriteLine("1. Add a new shippingCompany");
                Console.WriteLine("2. View all shippingCompanys");
                Console.WriteLine("3. Update a shippingCompany");
                Console.WriteLine("4. Delete a shippingCompany");
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
                            shippingCompanyBusiness.Add();
                            break;
                        case 2:
                            shippingCompanyBusiness.ViewAll();
                            break;
                        case 3:
                            shippingCompanyBusiness.Update();
                            break;
                        case 4:
                            shippingCompanyBusiness.Delete();
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