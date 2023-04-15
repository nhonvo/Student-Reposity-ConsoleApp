namespace Exercise_2.GUI
{
    public class Presentation
    {
        CustomerPresentation c = new CustomerPresentation();
        ProductPresentation p = new ProductPresentation();
        ShippingCompanyPresentation s = new ShippingCompanyPresentation();
        OrderPresentation o = new OrderPresentation();
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Select an option: \n");
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Product");
                Console.WriteLine("3. ShippingCompany");
                Console.WriteLine("4. Order");
                Console.WriteLine("5. Exit");

                int option = 0;
                while (option < 1 || option > 5)
                {
                    System.Console.WriteLine("Enter your choice...");
                    if (!int.TryParse(Console.ReadLine(), out option))
                        System.Console.WriteLine("Invalid input!!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (option)
                    {
                        case 1:
                            c.CustomerMenu();
                            break;
                        case 2:
                            p.ProductMenu();
                            break;
                        case 3:
                            s.ShippingCompanyMenu();
                            break;
                        case 4:
                            o.OrderMenu();
                            break;
                        case 5:
                            exit = true;
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