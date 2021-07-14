namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMovieNameToNotNullColumn : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ALTER COLUMN name NVARCHAR(20) NOT NULL");
        }
        
        public override void Down()
        {
        }
    }
}
