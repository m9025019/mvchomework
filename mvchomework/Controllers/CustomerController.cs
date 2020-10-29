using mvchomework.Models;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using mvchomework.Controllers;

namespace mvchomework.Controllers
{
    public class CustomerController : Controller
    {
        private customerEntities db = new customerEntities();
        // GET: Customer
        public ActionResult Index()
        {
            var Customer = db.客戶聯絡人.Include(c => c.客戶資料);
            return View(Customer.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶聯絡人 customer)
        {
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(customer);
                db.SaveChanges();
                //repo.Add(department);
                //repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            //ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName");

            return View(customer);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var customer = db.客戶聯絡人.Find(id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id.Value);
            //var dept = repo.Get單一筆部門資料(id.Value);


            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", customer.客戶Id);
            //ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName", dept.InstructorID);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            //return View(db.Department.Find(id.Value));

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶聯絡人 customer)
        //public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶聯絡人.Find(id);
                //var item = repo.All().FirstOrDefault(p => p.DepartmentID == id);
                //var item = repo.Get單一筆部門資料(id);
                //item.Name = department.Name;
                //item.Budget = department.Budget;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;
                item.InjectFrom(customer);


                db.SaveChanges();
                //repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            var cus = db.客戶聯絡人.Find(id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            //var dept = repo.Get單一筆部門資料(id);

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", customer.客戶Id);
            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            //return View(db.Department.Find(id));
            return View(cus);
        }

        public ActionResult Details(int? id)
        {
            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            //var dept = repo.Get單一筆部門資料(id.Value);
            客戶聯絡人 customer = db.客戶聯絡人.Find(id);
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", customer.客戶Id);
            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            return View(customer);

        }

        public ActionResult Delete(int? id)
        {
            客戶聯絡人 customer = db.客戶聯絡人.Find(id);
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", customer.客戶Id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id.Value);
            //var dept = repo.Get單一筆部門資料(id.Value);


            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.客戶聯絡人.Remove(db.客戶聯絡人.Find(id));
            db.SaveChanges();
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            //var dept = repo.Get單一筆部門資料(id);

            //repo.Delete(dept);
            //repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}