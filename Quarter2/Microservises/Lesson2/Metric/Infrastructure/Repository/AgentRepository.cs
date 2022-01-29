using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using GeekBrains.Learn.Core.DAO.Model;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Repository
{
    /// <summary>
    /// Agent's repository
    /// </summary>
    public class AgentRepository : IAgentRepository
    {
        private const string _tableName = "Agents";
        private readonly string _connectionString;

        /// <inheritdoc/>
        public AgentRepository(StartOptions startOptions)
{
            _connectionString = startOptions.Value;
        }

        private string TableName
        {
            get { return _tableName; }
        }

        /// <inheritdoc/>
        public void Create(Agent entity)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            var agentDb = GetByUri(entity.Uri);
            if (agentDb == null)
            {
                connection.Execute("INSERT INTO " + TableName + "(Uri) VALUES(@uri);",
                    new { entity.Uri });
            }
        }

        /// <inheritdoc/>
        public List<Agent> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Query<Agent>("SELECT * FROM " + TableName + " ORDER BY Uri").ToList();
        }

        /// <inheritdoc/>
        public Agent GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.QuerySingleOrDefault<Agent>("SELECT * FROM " + TableName + " WHERE Id = @id;",
                new { id });
        }

        /// <inheritdoc/>
        public Agent GetByUri(string uri)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.QuerySingleOrDefault<Agent>("SELECT * FROM " + TableName + " WHERE Uri = @uri;",
                new { uri });
        }
    }
}
