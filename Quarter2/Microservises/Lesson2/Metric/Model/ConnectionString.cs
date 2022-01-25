namespace GeekBrains.Learn.Core.DAO.Model
{
    /// <summary>
    /// Global connection string class
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ConnectionString(string connectionString)
        {
            Value = connectionString;
        }

        /// <summary>
        /// Connection string value
        /// </summary>
        public string Value { get; }
    }
}
