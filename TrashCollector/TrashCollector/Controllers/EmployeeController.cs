﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using Microsoft.AspNet.Identity;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db;

        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            var pickups = db.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupStatus == false).ToList();
            List<Customer> pickupsToday = pickups.Where(p => p.PickupDay == DateTime.Now.DayOfWeek.ToString()).ToList();
            return View(pickupsToday);
        }
        //[HttpPost]
        //public ActionResult Index(List<Customer> customers)
        //{

        //}

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {            
            try
            {
                var userId = User.Identity.GetUserId();
                employee.Email = db.Users.Where(u => u.Id == userId).Select(u => u.Email).FirstOrDefault();
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult CompletePickup(int id)
        {
            var currentCustomer = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            currentCustomer.PickupStatus = true;
            currentCustomer.Bill += 25;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
