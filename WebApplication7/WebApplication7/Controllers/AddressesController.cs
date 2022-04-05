using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    /// <summary>
    /// Controller for manipulations in table Address
    /// </summary>
    public class AddressesController : Controller
    {
        /// <summary>
        /// Set context Model1
        /// </summary>
        private Model1 db = new Model1();

        /// <summary>
        /// Controller index address screen
        /// </summary>
        /// <returns>Adresses list</returns>
        // GET: Addresses
        public ActionResult Index(string searchString)
        {
            var addresses = from s in db.Addresses
                            select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                addresses = addresses.Where(s => s.CPFCustomer == searchString)
                                     .OrderBy(s => s.NameAddress);
            }
            else
            {
                addresses = addresses.OrderBy(s => s.NameAddress);
            }
            return View(addresses.ToList());
        }

        /// <summary>
        /// Controler details address screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>An address infos</returns>
        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }
        
        /// <summary>
        /// Controller create address scren
        /// </summary>
        /// <returns>Address created</returns>
        public ActionResult Create()
        {
            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name");
            return View();
        }

        /// <summary>
        /// Controller validade create address screen 
        /// </summary>
        /// <param name="address">value address</param>
        /// <returns>address</returns>
        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAddress,CPFCustomer,City,Country,MoreInfo,NameAddress,Number,PostalCode,Region,Street")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name", address.CPFCustomer);
            return View(address);
        }

        /// <summary>
        /// Controller edit address screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Screen for edition infos</returns>
        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name", address.CPFCustomer);
            return View(address);
        }

        /// <summary>
        /// Controller validate edit address screen
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Addresses list updated</returns>
        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAddress,CPFCustomer,City,Country,MoreInfo,NameAddress,Number,PostalCode,Region,Street")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPFCustomer = new SelectList(db.Customers, "CPF", "Name", address.CPFCustomer);
            return View(address);
        }

        /// <summary>
        /// Controller delete address screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>validate address</returns>
        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        /// <summary>
        /// Controller validade delete address screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Addresses list updated</returns>
        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
