using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAn__Demo1_;
using PagedList;
using PagedList.Mvc;

namespace WebDoAn__Demo1_.Controllers
{
    public class TrangChuController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();
        // GET: TrangChu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    
    }
}