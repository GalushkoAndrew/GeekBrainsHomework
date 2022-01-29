using FluentMigrator;

namespace GeekBrains.Learn.Core.MetricsManager.Controller.Migrations
{
    /// <summary>
    /// First migration
    /// </summary>
    [Migration(1)]
    public class FirstMigration : Migration
    {
        private const string _agentsTableName = "Agents";

        /// <inheritdoc/>
        public override void Up()
        {
            Create.Table(_agentsTableName)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Uri").AsString(1024);
        }

        /// <inheritdoc/>
        public override void Down()
        {
            Delete.Table(_agentsTableName);
        }
    }
}
