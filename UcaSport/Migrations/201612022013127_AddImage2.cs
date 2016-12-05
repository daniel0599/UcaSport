namespace UcaSport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "ImgUrl", c => c.String(nullable: false));
        }
    }
}
