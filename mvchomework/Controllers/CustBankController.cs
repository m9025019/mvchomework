using mvchomework.Models;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvchomework.Controllers
{
    public class CustBankController : Controller
    {
        客戶銀行資訊Repository CusBank;

        public CustBankController()
        {
            CusBank = RepositoryHelper.Get客戶銀行資訊Repository();
            //repoPerson = RepositoryHelper.GetPersonRepository(repo.UnitOfWork);
        }

        // GET: CustBank
        public ActionResult Index()
        {
            return View(CusBank.All());
        }

        public ActionResult Create()
        {
            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName");


            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶銀行資訊 cusbank)
        {
            if (ModelState.IsValid)
            {
                //db.Department.Add(department);
                //db.SaveChanges();
                CusBank.Add(cusbank);
                CusBank.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName");

            return View(cusbank);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            //var dept = db.Department.Find(id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id.Value);
            var cus = CusBank.Get單一筆部門資料(id.Value);


            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);
            //ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName", dept.InstructorID);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            //return View(db.Department.Find(id.Value));

            return View(cus);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶銀行資訊 cusbank)
        //public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                //var item = db.Department.Find(id);
                //var item = repo.All().FirstOrDefault(p => p.DepartmentID == id);
                var item = CusBank.Get單一筆部門資料(id);
                //item.Name = department.Name;
                //item.Budget = department.Budget;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;
                item.InjectFrom(cusbank);


                //db.SaveChanges();
                CusBank.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            //var dept = db.Department.Find(id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            var cus = CusBank.Get單一筆部門資料(id);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);
            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            //return View(db.Department.Find(id));
            return View(cus);
        }

        public ActionResult Details(int? id)
        {
            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            var cus = CusBank.Get單一筆部門資料(id.Value);


            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            return View(cus);

        }

        public ActionResult Delete(int? id)
        {
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id.Value);
            var cus = CusBank.Get單一筆部門資料(id.Value);


            return View(cus);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            //db.Department.Remove(db.Department.Find(id));
            //db.SaveChanges();
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            var dept = CusBank.Get單一筆部門資料(id);

            CusBank.Delete(dept);
            CusBank.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}