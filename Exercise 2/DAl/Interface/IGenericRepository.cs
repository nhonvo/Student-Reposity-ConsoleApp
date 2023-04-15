using System.Linq.Expressions;

namespace Exercise_2.DAl.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Adds a new entity of type T to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Adds a collection of entities of type T to the database.
        /// </summary>
        /// <param name="entity">The collection of entities to add.</param>
        void AddRange(IEnumerable<T> entity);

        /// <summary>
        /// Checks if any entity of type T satisfies the given filter.
        /// </summary>
        /// <param name="filter">The filter condition.</param>
        /// <returns>True if any entity satisfies the filter, else false.</returns>
        bool Any(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Counts the number of entities of type T that satisfy the given filter.
        /// </summary>
        /// <param name="filter">The filter condition.</param>
        /// <returns>The count of entities that satisfy the filter.</returns>
        int Count(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Counts the total number of entities of type T in the database.
        /// </summary>
        /// <returns>The total count of entities.</returns>
        int Count();

        /// <summary>
        /// Returns the entity of type T with the given id.
        /// </summary>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>The entity with the given id.</returns>
        T GetById(object id);

        /// <summary>
        /// Returns a paged list of entities of type T from the database.
        /// </summary>
        /// <param name="pageIndex">The index of the page to retrieve.</param>
        /// <param name="pageNumber">The number of entities to include in each page.</param>
        /// <returns>A paged list of entities.</returns>
        IEnumerable<T> GetAll(int pageIndex, int pageNumber);

        /// <summary>
        /// Returns a list of all entities of type T from the database.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Updates the given entity of type T in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Updates a collection of entities of type T in the database.
        /// </summary>
        /// <param name="entities">The collection of entities to update.</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Deletes the given entity of type T from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes a collection of entities of type T from the database.
        /// </summary>
        /// <param name="entities">The collection of entities to delete.</param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Deletes the entity of type T with the given id from the database.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        void Delete(object id);
        /// <summary>
        /// Gets the state of the specified entity and returns a string representation of that state.
        /// </summary>
        /// <param name="entity">The entity to check the state of.</param>
        /// <returns>A string representation of the state of the entity.</returns>
        string GetEntityState(T entity);

    }
}