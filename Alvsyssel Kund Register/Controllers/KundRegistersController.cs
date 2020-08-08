using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alvsyssel_Kund_Register.Models;

namespace Alvsyssel_Kund_Register.Controllers
{
    public class KundRegistersController : Controller
    {
        private KundregisterV2 db = new KundregisterV2();

        // GET: KundRegisters
        public ActionResult Index()
        {
            return View(db.KundRegisters.ToList());
        }

        // GET: KundRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundRegister kundRegister = db.KundRegisters.Find(id);
            if (kundRegister == null)
            {
                return HttpNotFound();
            }
            return View(kundRegister);
        }

        // GET: KundRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KundRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kund_Id,Kund_Fornamn,Kund_Efternamn,Produkt_id,Datum_kop,Datum_installation,Kund_telefon_nr,Kund_e_mail,Kund_adress,Kund_post_nr,Kund_region,Medgivande_att_bli_kontaktad,Admin_id,Senast_andrad,Order_nr,Produkt_typ,GDPR__Medgivande,C30_Dagar,Kurs_10_Månader,Paddar_Bäst_Före,C3år_Byta_Batteri")] KundRegister kundRegister)
        {
            if (ModelState.IsValid)
            {
                db.KundRegisters.Add(kundRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kundRegister);
        }

        // GET: KundRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundRegister kundRegister = db.KundRegisters.Find(id);
            if (kundRegister == null)
            {
                return HttpNotFound();
            }
            return View(kundRegister);
        }

        // POST: KundRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kund_Id,Kund_Fornamn,Kund_Efternamn,Produkt_id,Datum_kop,Datum_installation,Kund_telefon_nr,Kund_e_mail,Kund_adress,Kund_post_nr,Kund_region,Medgivande_att_bli_kontaktad,Admin_id,Senast_andrad,Order_nr,Produkt_typ,GDPR__Medgivande,C30_Dagar,Kurs_10_Månader,Paddar_Bäst_Före,C3år_Byta_Batteri")] KundRegister kundRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kundRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kundRegister);
        }

        // GET: KundRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundRegister kundRegister = db.KundRegisters.Find(id);
            if (kundRegister == null)
            {
                return HttpNotFound();
            }
            return View(kundRegister);
        }

        // POST: KundRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KundRegister kundRegister = db.KundRegisters.Find(id);
            db.KundRegisters.Remove(kundRegister);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
