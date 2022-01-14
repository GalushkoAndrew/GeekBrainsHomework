using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Base;

namespace GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces
{
    /// <summary>
    /// Main entity repository
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public interface IRepository<T> : IRepositoryBase<T>
        where T : class, IHaveId
    {
        /// <summary>
        /// Get filtered entity list
        /// </summary>
        List<T> GetListFiltered(DateTime fromTime, DateTime toTime);
    }
}
