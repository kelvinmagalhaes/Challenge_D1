using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    /// <summary>
    /// Controller for manipulations in table Phone
    /// </summary>
    public class PhonesController : Controller
    {
        /// <summary>
        /// Set context Model1
        /// </summary>
        private Model1 db = new Model1();

        /// <summary>
        /// Controller index phone screen
        /// </summary>
        /// <returns>Phones list</returns>
        // GET: Phones
        public ActionResult Index(string cpf)
        {
            var phones = from s in db.Phones
                         select s;

            if (!string.IsNullOrEmpty(cpf))
            {
                phones = phones.Where(s => s.CPFCustomer == cpf);
            }
            else
            {
                phones = phones.OrderBy(s => s.NamePhone);
            }
            return View(phones.ToList());
        }

        /// <summary>
        /// Controler details phone screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>A phone infos</returns>
        // GET: Phones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        /// <summary>
        /// Controller create phone screen 
        /// </summary>
        /// <param name="address">value address</param>
        /// <returns>address</returns>
        // GET: Phones/Create
        public ActionResult Create()
        {
            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name");
            return View();
        }

        /// <summary>
        /// Controller validade create phone screen 
        /// </summary>
        /// <param name="address">value address</param>
        /// <returns>address</returns>
        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhone,CPFCustomer,IsPrivate,NamePhone,PhoneNumber")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name", phone.CPFCustomer);
            return View(phone);
        }

        /// <summary>
        /// Controller edit phone screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Screen for edition infos</returns>
        // GET: Phones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name", phone.CPFCustomer);
            return View(phone);
        }

        /// <summary>
        /// Controller validate edit phone screen
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Addresses list updated</returns>
        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhone,CPFCustomer,IsPrivate,NamePhone,PhoneNumber")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name", phone.CPFCustomer);
            return View(phone);
        }

        /// <summary>
        /// Controller delete address screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>validate phone</returns>
        // GET: Phones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        /// <summary>
        /// Controller validade delete phone screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Phone list updated</returns>
        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose object db
        /// </summary>
        /// <param name="disposing">dispose confirmed.</param>
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
