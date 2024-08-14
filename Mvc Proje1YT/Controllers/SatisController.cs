using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Proje1YT.Models.Entity;
namespace Mvc_Proje1YT.Controllers
{
    public class SatisController : Controller
    {
        MvcProjeDbStokEntities db = new MvcProjeDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR P)
        {
            db.TBLSATISLAR.Add(P);
            db.SaveChanges();
            return View("Index");
        }













    }
}
