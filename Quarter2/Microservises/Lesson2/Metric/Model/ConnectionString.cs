namespace GeekBrains.Learn.Core.DAO.Model
{
    public class ConnectionString
    {
        public ConnectionString(string connectionString)
        {
            Value = connectionString;
        }

        public string Value { get; }
    }
}
