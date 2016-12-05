namespace UcaSport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "color", c => c.String());
            AddColumn("dbo.Productoes", "Weight", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Weight");
            DropColumn("dbo.Productoes", "color");
        }
    }
}
