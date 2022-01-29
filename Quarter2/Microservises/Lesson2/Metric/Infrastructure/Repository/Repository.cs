using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using GeekBrains.Learn.Core.DAO.Model;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;
using static Dapper.SqlMapper;

namespace GeekBrains.Learn.Core.Infrastructure.Repository
{
    /// <summary>
    /// Main repository
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public class Repository<T> : IRepository<T>
         where T : class, IMetric, new()
    {
        private readonly string _connectionString;

        /// <inheritdoc/>
        public Repository(StartOptions startOptions)
        {
            _connectionString = startOptions.Value;
        }

        private string TableName
        {
            get { return typeof(T).Name + "s"; }
        }

        /// <inheritdoc/>
        public T Create(T entity)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            var transaction = connection.BeginTransaction();

            connection.Execute("INSERT INTO " + TableName + "(Value, Date) VALUES(@value, @date);",
                new { entity.Value, entity.Date });

            int rowId = connection.QuerySingleOrDefault<int>("SELECT last_insert_rowid();");

            transaction.Commit();

            return Get(rowId);
        }

        /// <inheritdoc/>
        public int Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Execute("DELETE FROM " + TableName + " WHERE Id = @id;", new { id });
        }

        /// <inheritdoc/>
        public T Get(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.QuerySingleOrDefault<T>("SELECT * FROM " + TableName + " WHERE Id = @id;",
                new { id });
        }

        /// <inheritdoc/>
        public List<T> GetFilteredList(DateTime fromTime, DateTime toTime)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Query<T>("SELECT * FROM " + TableName + " WHERE Date >= @fromTime AND Date <= @toTime;",
                new { fromTime, toTime }).ToList();
        }

        /// <inheritdoc/>
        public T Update(T entity)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute("UPDATE " + TableName + " SET Value = @value, Date = @date WHERE Id = @id;",
                new { entity.Value, entity.Date, entity.Id });

            return Get(entity.Id);
        }
    }
}
