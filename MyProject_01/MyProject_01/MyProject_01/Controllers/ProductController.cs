using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject_01.Context;
namespace MyProject_01.Controllers
{
    public class ProductController : Controller
    {
        WebBanSachEntities4 db = new WebBanSachEntities4();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = db.Products.Where(n => n.Id == Id).FirstOrDefault();//lấy 1 cái duy nhất;
            return View(objProduct);
        }

    }
}