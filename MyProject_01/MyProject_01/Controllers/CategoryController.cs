using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject_01.Context;
namespace MyProject_01.Controllers
{
    public class CategoryController : Controller
    {
        WebBanSachEntities db = new WebBanSachEntities();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = db.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var lstProductToCate = db.Products.Where(n => n.CategoryId == Id).ToList();
            return View(lstProductToCate);
        }
    }
}