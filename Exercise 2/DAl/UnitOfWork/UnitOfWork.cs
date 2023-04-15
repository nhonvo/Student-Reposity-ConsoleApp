using Exercise_2.DAl.Interface;
using Exercise_2.DAl.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Exercise_2.DAl.NSUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed;
        public ICustomerRepository _repoCustomers { get; }

        public IOrderRepository _repoOrders { get; }

        public IShippingCompanyRepository _repoShippingCompanies { get; }

        public IProductRepository _repoProducts { get; }

        public IOrderDetailRepository _repoOrderDetails { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repoCustomers = new CustomerRepository(_context);
            _repoOrders = new OrderRepository(_context);
            _repoShippingCompanies = new ShippingCompanyRepository(_context);
            _repoProducts = new ProductRepository(_context);
            _repoOrderDetails = new OrderDetailRepository(_context);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}