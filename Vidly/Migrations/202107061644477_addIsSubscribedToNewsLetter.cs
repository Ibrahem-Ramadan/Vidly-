namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsSubscribedToNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedtoNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedtoNewsLetter");
        }
    }
}
