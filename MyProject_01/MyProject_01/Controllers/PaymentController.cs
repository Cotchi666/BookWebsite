using MyProject_01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject_01.Models;
using MyProject_01.Context;
namespace MyProject_01.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        WebBanSachEntities4 db = new WebBanSachEntities4();
        public ActionResult Index()
        {
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //lấy thông tin từ biến session
                var lstCart = (List<Cart>)Session["cart"];
                // gán dữ liệu cho Order
                OrderInfo OI = new OrderInfo();
                OI.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                OI.UserId = int.Parse(Session["idUser"].ToString());
                OI.CreatedOnUtc = DateTime.Now;
                OI.Status = 1;
                db.OrderInfoes.Add(OI);
                db.SaveChanges();

                //Lấy OrderID vừa mới tạo lưu vào bảng OrderDetail
                int orderIDDetail = OI.Id;

                List<OrderDetail> listOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail OD = new OrderDetail();
                    OD.Quantity = item.Quantity;
                    OD.OrderId = orderIDDetail;
                    OD.ProductId = item.Product.Id;
                    listOrderDetail.Add(OD);


                }
                db.OrderDetails.AddRange(listOrderDetail);
                db.SaveChanges();
            }
            return View();
            
        }
    }
}