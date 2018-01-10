namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
