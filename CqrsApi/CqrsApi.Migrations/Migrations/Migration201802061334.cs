using FluentMigrator;

namespace CqrsApi.Migrations.Migrations
{
    [Migration(201802061334)]
    public class Migration201802061334 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Customers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable().Unique("Customers_Email_Uniq");

            Create.Table("Orders")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Price").AsDecimal(19, 4).NotNullable()
                .WithColumn("CreatedDate").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("CustomerId").AsInt32().ForeignKey("FK_Orders_Customers", "Customers", "Id");
        }
    }
}