namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropaddressinEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "extraPickupDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Address", c => c.String());
            DropColumn("dbo.Customers", "extraPickupDay");
        }
    }
}
