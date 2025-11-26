using lab7.Data;
using lab7.Models;
using lab7.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace lab7.Controllers
{
    public class StudentsController : Controller
    {
        private lab7Context db = new lab7Context();

        // GET: Students
        public ActionResult Index(string search, string campus, string sortOrder, int? page)
        {
            var viewModel = new StudentIndexViewModel();
            var students = db.Students.Include(s => s.Campus);


            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            ViewBag.AddressSortParm = sortOrder == "Address" ? "address_desc" : "Address";
            
            ViewBag.CampusSortParm = sortOrder == "Campus" ? "campus_desc" : "Campus";


           
            if (!String.IsNullOrEmpty(search))
            {
             
                students = students.Where(s => s.Name.Contains(search) || s.Address.Contains(search));
                viewModel.Search = search;
                ViewBag.Search = search; 
            }

            
            if (!String.IsNullOrEmpty(campus))
            {
                students = students.Where(s => s.Campus.Name == campus);
                viewModel.Campus = campus; 
            }


            

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "Address":
                    students = students.OrderBy(s => s.Address);
                    break;
                case "address_desc":
                    students = students.OrderByDescending(s => s.Address);
                    break;
                case "Campus":
                    
                    students = students.OrderBy(s => s.Campus.Name);
                    break;
                case "campus_desc":
                    students = students.OrderByDescending(s => s.Campus.Name);
                    break;
                default: 
                    students = students.OrderBy(s => s.Name);
                    break;
            }



            viewModel.CampusesWithCount = from s in students
                                          group s by s.Campus.Name into g
                                          select new CampusWithCount
                                          {
                                              CampusName = g.Key,
                                              StudentCount = g.Count()
                                          };
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

           
            viewModel.Students = students.ToPagedList(pageNumber, pageSize);

            
            return View(viewModel);
        }

        public ActionResult Create()
        {
            
            ViewBag.CampusID = new SelectList(db.UniversityCampus, "ID", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "Name,Address,CampusID")] Student student)
        {
            
            student.ID = Guid.NewGuid().ToString();

            
            ModelState.Remove("ID");

            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.CampusID = new SelectList(db.UniversityCampus, "ID", "Name", student.CampusID);

            return View(student);
        }
    }
} 