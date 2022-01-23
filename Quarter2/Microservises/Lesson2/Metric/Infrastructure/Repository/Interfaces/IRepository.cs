using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces
{
    /// <summary>
    /// Main entity repository
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public interface IRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Get filtered entity list
        /// </summary>
        List<T> GetFilteredList(DateTime fromTime, DateTime toTime);
    }
}
