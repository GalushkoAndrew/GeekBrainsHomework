using System.Collections.Generic;
using System.Linq;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Domain.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TEntity"> <see cref="IEntity"/></typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// DbContext
        /// </summary>
        protected readonly TimeSheetsDbContext _dbContext;

        /// <inheritdoc/>
        public Repository(TimeSheetsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns dbSet
        /// </summary>
        protected DbSet<TEntity> Entities
        {
            get { return _dbContext.Set<TEntity>(); }
        }

        /// <inheritdoc/>
        public TEntity Create(TEntity entity)
        {
            Entities.Add(entity);
            Save();
            return entity;
        }

        /// <inheritdoc/>
        public int Delete(TEntity entity)
        {
            Entities.Remove(entity);
            return Save();
        }

        /// <inheritdoc/>
        public TEntity GetById(int id)
        {
            return Entities.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<TEntity> GetPageList(int skip, int take)
        {
            return Entities.OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
        }

        /// <inheritdoc/>
        public int Update(TEntity entity)
        {
            var origin = Entities.FirstOrDefault(x => x.Id == entity.Id);
            if (origin == null)
            {
                return 0;
            }
            _dbContext.Entry(origin).CurrentValues.SetValues(entity);
            return Save();
        }

        /// <summary>
        /// Save changes
        /// </summary>
        protected int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
