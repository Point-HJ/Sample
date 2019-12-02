namespace Näytevarasto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CompanyID");
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
    }
}
