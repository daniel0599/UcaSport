namespace UcaSport.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UcaSport.DAL.SportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UcaSport.DAL.SportContext";
        }

        protected override void Seed(UcaSport.DAL.SportContext context)
        {
            var categories = new List<Categoria>
            {
                new Categoria {Nombre = "Tecnologia" },
                new Categoria {Nombre = "Ropa" },
                new Categoria {Nombre = "Deportes" }
            };

            categories.ForEach(c => context.Categorias.AddOrUpdate(p => p.Nombre, c));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
