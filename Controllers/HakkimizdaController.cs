using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjesi.Models.DataContext;
using WebProjesi.Models.Model;

namespace WebProjesi.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        WebDBContext db = new WebDBContext();
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();
                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h);
        }
    }
}