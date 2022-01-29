namespace GeekBrains.Learn.Core.DAO.Model
{
    /// <summary>
    /// Global options class
    /// </summary>
    public class StartOptions
    {
        /// <summary>
        /// ctor
        /// </summary>
        public StartOptions(string connectionString, string uri, string managerUri = null)
        {
            Value = connectionString;
            LocalUri = uri;
            ManagerUri = managerUri;
        }

        /// <summary>
        /// Connection string value
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Uri value
        /// </summary>
        public string LocalUri { get; }

        /// <summary>
        /// Manager Uri value
        /// </summary>
        public string ManagerUri { get; }
    }
}
