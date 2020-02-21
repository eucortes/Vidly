namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres(id,name)values(1,'Comedy')");
            Sql("insert into genres(id,name)values(2,'Action')");
            Sql("insert into genres(id,name)values(3,'Family')");
            Sql("insert into genres(id,name)values(4,'Romance')");
            Sql("insert into genres(id,name)values(5,'Triller')");
            Sql("insert into genres(id,name)values(6,'Kids')");
        }
        
        public override void Down()
        {
        }
    }
}
