
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication7.Models;
using PagedList;

namespace WebApplication7.Controllers
{
    /// <summary>
    /// Controller for manipulations in table Customers
    /// </summary>
    public class CustomersController : Controller
    {
        /// <summary>
        /// Set context Model1
        /// </summary>
        private Model1 db = new Model1();

        /// <summary>
        /// Controller index customer screen
        /// </summary>
        /// <param name="searchString">Name search</param>
        /// <param name="page">page index</param>
        /// <returns></returns>
        public ActionResult Index(string searchString, int? page )
        {
            var customers = from s in db.Customers
                            select s;


            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()))
                                     .OrderBy(s=>s.Name);
            }
            else
            {
                customers = customers.OrderBy(s => s.Name);
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Controler details customer screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>An customer infos</returns>
        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /// <summary>
        /// Controler find  
        /// </summary>
        /// <param name="CPF">PrimaryKey</param>
        /// <returns>Addresses list</returns>
        public ActionResult Find(string CPF)
        {
            var addresses = from s in db.Addresses
                            select s;


            if (!string.IsNullOrEmpty(CPF))
            {
                addresses = addresses.Where(s => s.CPFCustomer == CPF)
                                     .OrderBy(s => s.NameAddress);
            }
            return View("~/WebApplication7/Models/Views/Addresses/Index.cshtml");
        }

        /// <summary>
        /// Controller validade create address screen 
        /// </summary>
        /// <param name="customer">value address</param>
        /// <returns>customer</returns>
        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Controller validade create address screen 
        /// </summary>
        /// <param name="customer">value address</param>
        /// <returns>customer</returns>
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPF,Date,Id,LinkFacebook,LinkInstagram,LinkLinkedin,LinkTwitter,Name,RG")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        /// <summary>
        /// Controller edit customers screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Screen for edition infos</returns>
        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /// <summary>
        /// Controller validate edit customers screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Screen for edition infos</returns>
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPF,Date,Id,LinkFacebook,LinkInstagram,LinkLinkedin,LinkTwitter,Name,RG")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        /// <summary>
        /// Controller delete customers screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Customers list updated</returns>
        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /// <summary>
        /// Controller validade delete customers screen
        /// </summary>
        /// <param name="id">PrimaryKey</param>
        /// <returns>Customers list updated</returns>
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
