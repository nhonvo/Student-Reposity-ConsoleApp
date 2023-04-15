using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Models;
using Exercise_2.DAl.NSUnitOfWork;
using Exercise_2.DAl.Repository;

namespace Exercise_2.BUS
{
    public class ShippingCompanyBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShippingCompanyRepository _repoShippingCompany;
        public ShippingCompanyBusiness(IUnitOfWork unitOfWork, IShippingCompanyRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repoShippingCompany = repo;
        }

        public void ViewAll()
        {
            var shippingCompanies = _repoShippingCompany.GetAll();
            Console.WriteLine("{0,-5} {1,-20}", "ID", "Name");
            Console.WriteLine("{0,-5} {1,-20}", new string('-', 5), new string('-', 20));
            foreach (ShippingCompany shippingCompany in shippingCompanies)
            {
                Console.WriteLine("{0,-5} {1,-20}", shippingCompany.Id, shippingCompany.Name);
            }
        }

        public void Add()
        {
            ShippingCompany shippingCompany = new ShippingCompany();
            shippingCompany.Name = "Shipping Company " + new Random().Next(1000);

            try
            {
                _unitOfWork.BeginTransaction();
                _repoShippingCompany.Add(shippingCompany);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't add " + shippingCompany.ToString());
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
            ShippingCompany shippingCompany = _repoShippingCompany.GetById(id);
            if (shippingCompany == null)
            {
                Console.WriteLine("Shipping company not found");
                return;
            }
            shippingCompany.Name = "Updated Shipping Company " + new Random().Next(1000);
            try
            {
                _unitOfWork.BeginTransaction();
                _repoShippingCompany.Update(shippingCompany);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't update " + shippingCompany.ToString());
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
            ShippingCompany shippingCompany = _repoShippingCompany.GetById(id);

            if (shippingCompany == null)
            {
                Console.WriteLine("Shipping company not found");
                return;
            }
            try
            {
                _unitOfWork.BeginTransaction();
                _repoShippingCompany.Delete(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Can't delete shipping company with ID " + id.ToString());
            }
        }
    }
}