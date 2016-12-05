using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UcaSport.Models;
using System.Data.Entity;
namespace UcaSport.DAL
{
    public class SportContext:DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Image> Images { get; set; }
        

    }
}