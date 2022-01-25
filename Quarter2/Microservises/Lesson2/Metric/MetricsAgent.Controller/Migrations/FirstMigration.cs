using FluentMigrator;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller.Migrations
{
    /// <summary>
    /// First migration
    /// </summary>
    [Migration(1)]
    public class FirstMigration : Migration
    {
        /// <inheritdoc/>
        public override void Down()
        {
            Delete.Table("CpuMetrics");
            Delete.Table("DotnetMetrics");
            Delete.Table("HddMetrics");
            Delete.Table("NetworkMetrics");
            Delete.Table("RamMetrics");
        }

        /// <inheritdoc/>
        public override void Up()
        {
            Create.Table("CpuMetrics")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Date").AsDateTime();
            Create.Table("DotnetMetrics")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Date").AsDateTime();
            Create.Table("HddMetrics")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Date").AsDateTime();
            Create.Table("NetworkMetrics")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Date").AsDateTime();
            Create.Table("RamMetrics")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Date").AsDateTime();
        }
    }
}
