using System.Linq.Expressions;
using Exercise_2.DAl.Interface;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2.DAl.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        // create
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void AddRange(IEnumerable<T> entity)
        {
            _dbSet.AddRange(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);
        // Read
        public bool Any(Expression<Func<T, bool>> filter) => _dbSet.Any(filter);
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter) => await _dbSet.AnyAsync(filter);
        public int Count(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
                return _dbSet.Count();
            return _dbSet.Count(filter);
        }
        public int Count() => _dbSet.Count();
        public T GetById(object id) => _dbSet.Find(id)!;
        public IEnumerable<T> GetAll(int pageIndex, int pageNumber) => _dbSet.Skip(pageIndex).Take(pageNumber).ToList();
        public IEnumerable<T> GetAll() => _dbSet.ToList();
        
        // Update
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
        // delete
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Delete(object id)
        {
            T entity = GetById(id);
            Delete(entity);
        }
        // checking
        public string GetEntityState(T entity)
        {
            EntityState state = _dbSet.Entry(entity).State;
            switch (state)
            {
                case EntityState.Added:
                    return "Object is being inserted";
                case EntityState.Modified:
                    return "Object is being updated";
                case EntityState.Deleted:
                    return "Object is being deleted";
                case EntityState.Detached:
                    _dbSet.Attach(entity);
                    return "Object is being attached";
                case EntityState.Unchanged:
                    _dbSet.Entry(entity).State = EntityState.Detached;
                    return "Object is being detached";
                default:
                    throw new ArgumentOutOfRangeException(nameof(state));
            }
        }

    }
}