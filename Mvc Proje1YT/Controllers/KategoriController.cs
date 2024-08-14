using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Proje1YT.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace Mvc_Proje1YT.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcProjeDbStokEntities db = new MvcProjeDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORİLER.ToList();
            var degerler=db.TBLKATEGORİLER.ToList().ToPagedList(sayfa, 4);
            return View(degerler); 
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİLER p1)
        {
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
       
            }
                
            db.TBLKATEGORİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SİL(int id)
        {
            var kategori = db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir" , ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORİLER p1)
        {
            var ktg = db.TBLKATEGORİLER.Find(p1.KATEGORİID);
            ktg.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}