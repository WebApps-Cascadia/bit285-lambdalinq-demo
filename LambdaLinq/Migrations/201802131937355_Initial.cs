namespace LambdaLinq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Edition", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Edition", c => c.Int(nullable: false));
        }
    }
}
