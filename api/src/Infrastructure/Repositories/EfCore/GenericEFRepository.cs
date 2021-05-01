using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository.EfCore
{
    public class GenericEFRepository<T> : IBaseRepository<T>, IBaseRepository where T : class
    {
        public GenericEFRepository(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context;

        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<T>();
                return _dbSet;
            }
        }

        public virtual IQueryable<T> All()
        {
            return All(false);
        }

        public virtual IQueryable<T> All(bool noTracking)
        {
            var result = DbSet.AsQueryable();
            return noTracking ? result.AsNoTracking() : result;
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return Filter(predicate, false);
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, bool noTracking)
        {
            var result = DbSet.Where(predicate).AsQueryable();

            return noTracking ? result.AsNoTracking() : result;
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0,
            int size = 50)
        {
            return Filter(filter, out total, false, index, size);
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total,
            bool noTracking, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();

            return noTracking ? resetSet.AsQueryable().AsNoTracking() : resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual T Find(Expression<Func<T, bool>> predicate, bool noTracking)
        {

            return noTracking
                ? DbSet.Where(predicate).AsNoTracking().FirstOrDefault()
                : DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual T Add(T entity)
        {
            var newEntry = DbSet.Add(entity);
            Context.SaveChanges();
            return newEntry.Entity;
        }

        public virtual int Count => DbSet.Count();

        public virtual int Delete(T entity)
        {
            DbSet.Remove(entity);
            return Context.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();
        }

        /// <summary>
        /// Adds an non-typed object to the repository. Checks the type before adding to see if it is comaptible 
        /// with the repository
        /// </summary>
        /// <param name="entity"></param>
        public void AddObject(object entity)
        {
            if (entity.GetType() == typeof(T))
            {
                Add((T)entity);
            }
        }

        /// <summary>
        /// Updates an non-typed object to the repository. Checks the type before updating to see if it is comaptible 
        /// with the repository
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateObject(object entity)
        {
            if (entity.GetType() == typeof(T))
            {
                Update((T)entity);
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = Includes(includeProperties);

            if (filter != null)
                query = query.Where(filter);

            return orderBy?.Invoke(query).AsQueryable() ?? query;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> Includes(string includeProperties)
        {
            var query1 = _dbSet.AsQueryable();
            foreach (var includeProperty in includeProperties.Split(
                new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query1 = _dbSet.Include(includeProperty);

            return query1;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var newEntry = await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();

            return newEntry.Entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return await Context.SaveChangesAsync();

        }
    }
}
