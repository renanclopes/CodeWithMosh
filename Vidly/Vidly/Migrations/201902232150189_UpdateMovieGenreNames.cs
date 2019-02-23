namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieGenreNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MovieGenres set Name = 'Action' WHERE Name = '1'");
            Sql("UPDATE MovieGenres set Name = 'Comedy' WHERE Name = '2'");
            Sql("UPDATE MovieGenres set Name = 'Family' WHERE Name = '3'");
            Sql("UPDATE MovieGenres set Name = 'Romance' WHERE Name = '4'");
        }
        
        public override void Down()
        {
        }
    }
}
