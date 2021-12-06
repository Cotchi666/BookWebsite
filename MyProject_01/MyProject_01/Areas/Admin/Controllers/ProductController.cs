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
        [ValidateInput(false)]
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
                        fileName = fileName + extension + " " + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"));
                        product.Avatar = fileName;

                        product.ImageUpLoad1.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));

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


    }
}