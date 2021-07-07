namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Value) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Value) VALUES ('Action')");
            Sql("INSERT INTO Genres (Value) VALUES ('Family')");
            Sql("INSERT INTO Genres (Value) VALUES ('Romance')");

        }
        
        public override void Down()
        {
        }
    }
}
