namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, Monthly)");
        }
        
        public override void Down()
        {
        }
    }
}
