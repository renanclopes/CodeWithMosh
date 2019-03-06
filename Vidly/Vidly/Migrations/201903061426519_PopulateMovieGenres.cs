namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) values ('Action')");
            Sql("INSERT INTO MovieGenres (Name) values ('Comedy')");
            Sql("INSERT INTO MovieGenres (Name) values ('Family')");
            Sql("INSERT INTO MovieGenres (Name) values ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
