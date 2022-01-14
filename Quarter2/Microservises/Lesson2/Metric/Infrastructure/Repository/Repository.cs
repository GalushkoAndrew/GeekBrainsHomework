using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Repository
{
    /// <summary>
    /// Main repository
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public class Repository<T> : IRepository<T>
         where T : class, IHaveId, new()
    {
        /// <inheritdoc/>
        public T Create(T entity)
        {
            return entity;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            return;
        }

        /// <inheritdoc/>
        public T Get(int id)
        {
            return new T();
        }

        /// <inheritdoc/>
        public List<T> GetListFiltered(DateTime fromTime, DateTime toTime)
        {
            return new List<T>();
        }

        /// <inheritdoc/>
        public T Update(T entity)
        {
            return entity;
        }
    }
}
