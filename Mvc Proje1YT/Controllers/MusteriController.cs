using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Proje1YT.Models.Entity;

namespace Mvc_Proje1YT.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcProjeDbStokEntities db = new MvcProjeDbStokEntities();

        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERİLER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERİAD.Contains(p));    
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERİLER.ToList();
           // return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERİLER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");

            }
            db.TBLMUSTERİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SİL(int id)
        {
            var musteri = db.TBLMUSTERİLER.Find(id);
            db.TBLMUSTERİLER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERİLER.Find(id);
            return View("MusteriGetir", mus);

        } 
        public ActionResult Guncelle(TBLMUSTERİLER p1)
        {
            var musteri = db.TBLMUSTERİLER.Find(p1.MUSTERİID);
            musteri.MUSTERİAD = p1.MUSTERİAD;
            musteri.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    
    }
}