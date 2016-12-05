using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease.Activities;

namespace UcaSport.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [StringLength(300)]
        public string ImageName { get; set; }
        public FileType fyletype {get; set;}
        public int ProductId { get; set;}
        public virtual Producto Producto { get; set; }


    }
}