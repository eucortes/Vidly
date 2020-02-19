namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes(id,signupfee,durationinmonts,DiscountRate)values" +
                "(1,0,0,0)," +
                "(2,30,1,10)," +
                "(3,90,3,15)," +
                "(4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
