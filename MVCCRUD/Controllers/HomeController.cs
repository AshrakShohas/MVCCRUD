using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Tables.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Table model)
        {
            _context.Tables.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Tables.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Table Model)
        {
            var data = _context.Tables.Where(x => x.StudentID == Model.StudentID).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = Model.StudentCity;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Tables.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Tables.Where(x => x.StudentID == id).FirstOrDefault();
            _context.Tables.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Data Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}