using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UcaSport.Models
{
    public class Producto
    {
        [Required(ErrorMessage = "El peso del producto es requerido")]
        public string Weight { get; set; }

        [DisplayName("URL de la Imagen")]
        [DataType(DataType.Url)]
      //  [Required(ErrorMessage ="Devbe agregar una imagen para el producto")]
        public string ImgUrl { get; set; }
        public int Id { get; set; }
        [DisplayName("Nombre del producto")]
        [Required(ErrorMessage ="Es requerido ingresar el nombre del producto")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string color { get; set; }
       
        [Required]
        public decimal Precio { get; set; }
        public int? CategoriaId { get; set; }//hace referencia a la foranea de categoria
     
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Image> Images { get; set; }

    }
}