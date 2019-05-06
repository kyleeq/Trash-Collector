using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using Microsoft.AspNet.Identity;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db;

        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == customerId).FirstOrDefault();
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                customer.ApplicationId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int Id)
        {
            var customerId = User.Identity.GetUserId();
            var customerPickupInfo = db.Customers.Where(c => c.ApplicationId == customerId).FirstOrDefault();
            return View(customerPickupInfo);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var edittedCustomer = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();
                edittedCustomer.FirstName = customer.FirstName;
                edittedCustomer.LastName = customer.LastName;
                edittedCustomer.Address = customer.Address;
                edittedCustomer.Zipcode = customer.Zipcode;
                edittedCustomer.PickupDay = customer.PickupDay;
                edittedCustomer.ExtraPickupDay = customer.ExtraPickupDay;
                edittedCustomer.SuspendStartDay = customer.SuspendStartDay;
                edittedCustomer.SuspendEndDay = customer.SuspendEndDay;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
