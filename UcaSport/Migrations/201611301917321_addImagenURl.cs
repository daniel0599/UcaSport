namespace UcaSport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImagenURl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "ImgUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "ImgUrl");
        }
    }
}
