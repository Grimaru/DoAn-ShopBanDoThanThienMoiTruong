using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAn__Demo1_;

namespace WebDoAn__Demo1_.Controllers
{
    public class LoginUserController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAccount(EcoFriendlyAdminUser _user)
        {
            var check = db.EcoFriendlyAdminUsers.Where(s => s.NameUser.Equals(_user.NameUser)
            && s.PasswordUser.Equals(_user.PasswordUser)).FirstOrDefault();
            if (check == null)
            {
                //_user.LoginErrorMessage = "Error Email or Password!";
                ViewBag.ErrorInfo = "Error Username or Password! Try again please!";
                return View("Index", _user);
            }
            else //login successfull
            {
                Session["IDUser"] = _user.ID;
                Session["NameUser"] = _user.NameUser;
                if (_user.PasswordUser == "Admin")
                {
                    return RedirectToAction("Index", "EcoFriendlyAdminUsers");
                }
                else
                {
                    return RedirectToAction("Product", "Product");
                }
            }
        }

        // GET: LoginUser
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(EcoFriendlyAdminUser _user)
        {
            //if (ModelState.IsValid)
            {
                var check = db.EcoFriendlyAdminUsers.FirstOrDefault(s => s.NameUser == _user.NameUser); //kiem tra NameUser da duoc dung dk chua
                if (check == null) //neu chua thi cho dang ky
                {
                    if (_user.PasswordUser != _user.ConfirmPassword)
                    {
                        ViewBag.ErrorInfo = "PasswordUser != ConfirmPassword";
                        return View("Register");
                    }
                    else
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        //_user.ID = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
                        db.EcoFriendlyAdminUsers.Add(_user);
                        db.SaveChanges();
                        return RedirectToAction("Index");


                    }
                }
                else
                {
                    ViewBag.ErrorInfo = "NameUser already exists. Use another NameUser please!"; //neu email do da duoc su dung roi thi hien thi thong bao
                    return View("Register");
                }
            }
            return View();
        }
    }
}