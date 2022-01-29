using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;

namespace GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces
{
    /// <summary>
    /// Agent's repository interface
    /// </summary>
    public interface IAgentRepository
    {
        /// <summary>
        /// Create entity
        /// </summary>
        void Create(Agent entity);

        /// <summary>
        /// Get single entity
        /// </summary>
        Agent GetByUri(string uri);

        /// <summary>
        /// Get entity list
        /// </summary>
        List<Agent> GetAll();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">entity id</param>
        Agent GetById(int id);
    }
}
