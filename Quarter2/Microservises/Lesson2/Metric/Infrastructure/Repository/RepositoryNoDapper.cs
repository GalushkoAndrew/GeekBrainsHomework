using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GeekBrains.Learn.Core.DAO.Model;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Repository
{
    /// <summary>
    /// Main repository, for history
    /// Example, based on System.Data.SQLite
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public class RepositoryNoDapper<T> : IRepository<T>
         where T : class, IMetric, new()
    {
        private readonly string _connectionString;

        /// <summary>
        /// ctor
        /// </summary>
        public RepositoryNoDapper(ConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
            CreateStructureDataBase();
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

            using var command = new SQLiteCommand(connection);

            command.CommandText = "INSERT INTO " + TableName + "(Value, Date) VALUES(@value, @date);";
            command.Parameters.AddWithValue("@value", entity.Value);
            command.Parameters.AddWithValue("@date", entity.Date);

            command.Prepare();
            command.ExecuteNonQuery();

            long rowId = connection.LastInsertRowId;

            transaction.Commit();

            return Get((int)rowId);
        }

        /// <inheritdoc/>
        public int Delete(int id)
        {
            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                using var command = new SQLiteCommand(connection);

                command.CommandText = "DELETE FROM " + TableName + " WHERE Id = @id;";
                command.Parameters.AddWithValue("@id", id);

                command.Prepare();
                command.ExecuteNonQuery();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <inheritdoc/>
        public T Get(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            T entity;
            using var command = new SQLiteCommand(connection);

            command.CommandText = "SELECT * FROM " + TableName + " WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                entity = new T
                {
                    Id = reader.GetInt32(0),
                    Value = reader.GetInt32(1),
                    Date = reader.GetDateTime(2)
                };

                return entity;
            }

            return null;
        }

        /// <inheritdoc/>
        public List<T> GetFilteredList(DateTime fromTime, DateTime toTime)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            List<T> entities = new List<T>();
            using var command = new SQLiteCommand(connection);

            command.CommandText = "SELECT * FROM " + TableName + " WHERE Date >= @fromTime AND Date <= @toTime;";
            command.Parameters.AddWithValue("@fromTime", fromTime);
            command.Parameters.AddWithValue("@toTime", toTime);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                entities.Add(new T
                {
                    Id = reader.GetInt32(0),
                    Value = reader.GetInt32(1),
                    Date = reader.GetDateTime(2)
                });
            }

            return entities;
        }

        /// <inheritdoc/>
        public T Update(T entity)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command = new SQLiteCommand(connection);

            command.CommandText = "UPDATE " + TableName + " SET Value = @value, Date = @date WHERE Id = @id;";
            command.Parameters.AddWithValue("@value", entity.Value);
            command.Parameters.AddWithValue("@date", entity.Date);
            command.Parameters.AddWithValue("@id", entity.Id);

            command.Prepare();
            command.ExecuteNonQuery();

            return Get(entity.Id);
        }

        private void CreateStructureDataBase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS " + TableName + "(Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Value INT, Date DATETIME);", connection);
            command.ExecuteNonQuery();
        }
    }
}
