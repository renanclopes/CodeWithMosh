namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes set Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MemberShipTypes set Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MemberShipTypes set Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MemberShipTypes set Name = 'Annually' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
