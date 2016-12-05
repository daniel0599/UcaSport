namespace UcaSport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 255),
                        fyletype = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Productoes", t => t.Producto_Id)
                .Index(t => t.Producto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Producto_Id", "dbo.Productoes");
            DropIndex("dbo.Images", new[] { "Producto_Id" });
            DropTable("dbo.Images");
        }
    }
}
