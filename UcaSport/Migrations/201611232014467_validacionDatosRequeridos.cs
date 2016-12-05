namespace UcaSport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacionDatosRequeridos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categorias", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Productoes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Productoes", "Precio", c => c.String(nullable: false));//se  agrega el cambio para que no permita null
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Nombre", c => c.String());
            AlterColumn("dbo.Productoes", "Precio", c => c.String());//para poder revertir el cambio
            AlterColumn("dbo.Categorias", "Nombre", c => c.String());
        }
    }
}
