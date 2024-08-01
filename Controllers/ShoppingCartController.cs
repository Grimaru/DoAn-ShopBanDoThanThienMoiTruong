using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAn__Demo1_;
using WebDoAn__Demo1_.Models;

namespace WebDoAn__Demo1_.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        // GET: ShoppingCart
        public ActionResult EmptyCart()
        {
            return View();
        }

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }

        public ActionResult AddtoCart(int id)
        {

            var pro = db.EcoFriendlyProducts.SingleOrDefault(s => s.ProductID == id);

            if (pro != null)
            {
                GetCart().Add(pro);
            }

            return RedirectToAction("ShowCart", "ShoppingCart");
        }


        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quan_pro = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quan_pro);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                total_item = cart.Total_quantity_in_Cart();
            }

            ViewBag.quantityCart = total_item;
            return PartialView("BagCart");

        }
        public ActionResult Error_InfoCus()
        {

            return View();

        }

        public ActionResult Continuos_Shopping()
        {
            return View();
        }

        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                EcoFriendlyOrderPro _order = new EcoFriendlyOrderPro();
                _order.DateOrder = DateTime.Now;
                _order.AddressDeliverry = form["address"];
                _order.IDCus = int.Parse(form["codeCus"]);
                db.EcoFriendlyOrderProes.Add(_order);
                foreach (var item in cart.Items)
                {
                    EcoFriendlyOrderDetail _order_detail = new EcoFriendlyOrderDetail();
                    _order_detail.IDOrder = _order.ID;
                    _order_detail.IDProduct = item._product.ProductID;
                    _order_detail.UnitPrice = (double)item._product.Price;
                    _order_detail.Quantity = item._quantity;
                    db.EcoFriendlyOrderDetails.Add(_order_detail);
                    
                    foreach (var p in db.EcoFriendlyProducts.Where(s => s.ProductID == _order_detail.IDProduct)) 
                    {
                        var update_quan_pro = p.Quantity - item._quantity; 
                        p.Quantity = update_quan_pro; 
                    }
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "ShoppingCart");
            }
            catch
            {
                return Content("Error checkout. Please check information of Customer...Thanks.");
            }
            return RedirectToAction("CheckOut_Success", "Home");
        }

        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }
}