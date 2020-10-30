using mvchomework.Models;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvchomework.Controllers
{
    public class CustDataController : Controller
    {
        //private customerEntities db = new customerEntities();
        客戶資料Repository CusData;

        public CustDataController()
        {
            CusData = RepositoryHelper.Get客戶資料Repository();
            //repoPerson = RepositoryHelper.GetPersonRepository(repo.UnitOfWork);
        }
        // GET: CustData
        public ActionResult Index()
        {
            //var CustDate = db.客戶資料.All();
            return View(CusData.All());
            //return View(db.客戶資料);
        }

        public ActionResult Create()
        {
            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName");
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");

            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶資料 cusdata)
        {
            if (ModelState.IsValid)
            {
                //db.Department.Add(department);
                //db.SaveChanges();
                CusData.Add(cusdata);
                CusData.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName");

            return View(cusdata);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            //var dept = db.Department.Find(id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id.Value);
            var cusda = CusData.Get單一筆部門資料(id.Value);


            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);
            //ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName", dept.InstructorID);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            //return View(db.Department.Find(id.Value));

            return View(cusda);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶資料 custdata)
        //public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                //var item = db.Department.Find(id);
                //var item = repo.All().FirstOrDefault(p => p.DepartmentID == id);
                var item = CusData.Get單一筆部門資料(id);
                //item.Name = department.Name;
                //item.Budget = department.Budget;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;
                item.InjectFrom(custdata);


                //db.SaveChanges();
                CusData.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            //var dept = db.Department.Find(id);
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            var cusda = CusData.Get單一筆部門資料(id);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);
            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            //return View(db.Department.Find(id));
            return View(cusda);
        }

        public ActionResult Details(int? id)
        {
            //ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            var cusda = CusData.Get單一筆部門資料(id.Value);


            //ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            return View(cusda);

        }

        public ActionResult Delete(int? id)
        {
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id.Value);
            var cusda = CusData.Get單一筆部門資料(id.Value);


            return View(cusda);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            //db.Department.Remove(db.Department.Find(id));
            //db.SaveChanges();
            //var dept = repo.All().FirstOrDefault(p => p.DepartmentID == id);
            var cusda = CusData.Get單一筆部門資料(id);

            CusData.Delete(cusda);
            CusData.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}