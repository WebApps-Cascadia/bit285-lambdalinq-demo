namespace LambdaLinq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Publication", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Publication", c => c.DateTime(nullable: false));
        }
    }
}
