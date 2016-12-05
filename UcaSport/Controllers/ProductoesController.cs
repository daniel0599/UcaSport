using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UcaSport.DAL;
using UcaSport.Models;

namespace UcaSport.Controllers
{
    public class ProductoesController : Controller
    {
        private SportContext db = new SportContext();

        // GET: Productoes
        public ActionResult Index(string categoria,string keyword, string sortBy)
        {
            var productos = db.Productos.Include(p => p.Categoria);
            if (!String.IsNullOrEmpty(categoria))//sirve para filtrar el producto por categoria, retorna a la vista los productos filtrados
            {
                productos = productos.Where(p =>p.Categoria.Nombre == categoria);
            }

            if (!String.IsNullOrEmpty(keyword))
            {
                productos = productos.Where(p => p.Nombre.Contains(keyword) ||   p.Descripcion.Contains(keyword) || p.Categoria.Nombre.Contains(keyword));//sirve para filtrar por una palabra clave en la desc, nombre o categoria
            }

            var categorias = productos.OrderBy(p => p.Categoria.Nombre).Select(p => p.Categoria.Nombre).Distinct();//filtrando por categorias en producto
            ViewBag.Categoria =new SelectList( categorias);//ViewBag permite pasar informacion del controlador a la vista

            switch (sortBy)
            {
                case "price lowest":
                    productos = productos.OrderBy(p => p.Precio);
                    break;
                case "price highest":
                    productos = productos.OrderByDescending(p => p.Precio);
                    break;
                default:
                    break;
            }

            return View(productos.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Include(i => i.Images).SingleOrDefault(i => i.Id == id);
            //   Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Precio,CategoriaId,Weight, color,ImgUrl")] Producto producto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if(upload != null && upload.ContentLength > 0)
                {
                    string pic = System.IO.Path.GetFileName(upload.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic);

                    upload.SaveAs(path);


                    var photo = new Image
                    {
                        ImageName = System.IO.Path.GetFileName(upload.FileName),
                        fyletype = FileType.Photo
                    };

                    producto.Images = new List<Image>();
                    producto.Images.Add(photo);




                }
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,CategoriaId,Weight,color,ImgUrl")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
