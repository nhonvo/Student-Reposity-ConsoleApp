using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;
using Exercise_2.DAl.NSUnitOfWork;

namespace Exercise_2.BUS
{
    public class ProductBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repoProduct;

        public ProductBusiness(IUnitOfWork unitOfWork, IProductRepository repoProduct)
        {
            _unitOfWork = unitOfWork;
            _repoProduct = repoProduct;
        }

        public void ViewAll()
        {
            var products = _repoProduct.GetAll();
            Console.WriteLine("{0,-5} {1,-20}", "ID", "Name");
            Console.WriteLine("{0,-5} {1,-20}", new string('-', 5), new string('-', 20));
            foreach (Product product in products)
            {
                Console.WriteLine("{0,-5} {1,-20}", product.Id, product.Name);
            }
        }

        public void Add()
        {
            Product product = new Product();
            product.Name = "Product " + new Random().Next(1000);

            try
            {
                _unitOfWork.BeginTransaction();
                _repoProduct.Add(product);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't add " + product.ToString());
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
            Product product = _repoProduct.GetById(id);
            if (product == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            product.Name = "Updated Product " + new Random().Next(1000);

            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't update " + product.ToString());
            }
        }

        public void Delete()
        {
            Console.WriteLine("Enter id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
            Product product = _repoProduct.GetById(id);

            if (product == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            try
            {
                _unitOfWork.BeginTransaction();
                _repoProduct.Delete(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't delete product with ID " + id.ToString());
            }
        }
    }
}