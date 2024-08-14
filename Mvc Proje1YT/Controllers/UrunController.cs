using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Proje1YT.Models.Entity;

namespace Mvc_Proje1YT.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcProjeDbStokEntities db =new MvcProjeDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value=i.KATEGORİID.ToString()
                  
                                           }).ToList();
            ViewBag.dgr = degerler; 
            return View();

        }
        [HttpPost]

        public ActionResult UrunEkle(TBLURUNLER p1)
        {
           var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORİID == p1.TBLKATEGORİLER.KATEGORİID).FirstOrDefault();
            p1.TBLKATEGORİLER = ktg;
            db.TBLURUNLER.Add(p1);

            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult Sİl(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORİID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir" , urun);
        } 

        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //urun.URUNKATEGORİ = p.URUNKATEGORİ;

            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORİID == p.TBLKATEGORİLER.KATEGORİID).FirstOrDefault();
            urun.URUNKATEGORİ = ktg.KATEGORİID;

            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}