namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) values (1)");
            Sql("INSERT INTO MovieGenres (Name) values (2)");
            Sql("INSERT INTO MovieGenres (Name) values (3)");
            Sql("INSERT INTO MovieGenres (Name) values (4)");
        }
        
        public override void Down()
        {
        }
    }
}
