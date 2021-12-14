using MyProject_01.Context;
using MyProject_01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace MyProject_01.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebBanSachEntities4 db = new WebBanSachEntities4();
        // GET: Admin/Product
        public ActionResult Index(string SearchString, int? pageNumber)
        {
            //var lstProduct = db.Products.Where(n => n.Name.StartsWith(SearchString)).ToList().ToPagedList(pageNumber ?? 1, 3);
            return View(db.Products.Where(n => n.Name.StartsWith(SearchString) || SearchString == null).ToList().ToPagedList(pageNumber ?? 1, 3));
        }

        public ActionResult Details(int Id)
        {
            var lstProduct = db.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        //[ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            
            //if (ModelState.IsValid)
            //{
                try
                {
                    if (product.ImageUpLoad1 != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad1.FileName);
                        string extension = Path.GetExtension(product.ImageUpLoad1.FileName);
                        fileName = fileName   /*+ " " + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))*/+ extension;
                        product.Avatar = fileName;

                        product.ImageUpLoad1.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));

                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");

                }
            //}

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productIsDe = db.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(productIsDe);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var productIsDe = db.Products.Where(n => n.Id == product.Id).FirstOrDefault();
            db.Products.Remove(productIsDe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productIsDe = db.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(productIsDe);
        }
        [HttpPost]
        public ActionResult Edit( Product product)
        {

                if (product.ImageUpLoad1 != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad1.FileName);
                    string extension = Path.GetExtension(product.ImageUpLoad1.FileName);
                    fileName = fileName   /*+ " " + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))*/+ extension;
                    product.Avatar = fileName;

                    product.ImageUpLoad1.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));

                }
                db.Entry(product).State=EntityState.Modified;
                db.SaveChanges();
                return View(product);

        }


    }
}