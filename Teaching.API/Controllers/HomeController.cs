using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teaching.API.Models;
using TeachingDb;
using TeachingDb.Entities;

namespace Teaching.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";
            Service service = new Service();

            var students = service.GetAllStudents();

            return View(students[0]);
           
            //return Content("OK");
        }


        public ActionResult ByClassroom(string classroomName)
        {
            Service service = new Service();

            var students = service.GetStudentByClassRoomName(classroomName);

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("View");
        }

        [HttpPost]
        public ActionResult Create(StudentCreateModel model)
        {
            var studentToAdd = new Student()
            {
                Name = model.Name,
                Surname = model.Surname,
                DateOfBirth = model.DateOfBirth
            };

            Service service = new Service();

            var students = service.CreateStudent(studentToAdd);

            return RedirectToAction("Create");
        }


        // public ActionResult 


        //public ActionResult Next()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var aa = db.Students.ToList();
        //    }

        //    return null;
        //}
    }
}
