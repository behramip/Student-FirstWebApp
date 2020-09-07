using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Teaching.API.Models;
using TeachingDb;
using TeachingDb.Entities;

namespace Teaching.API.Controllers
{
    public class StudentsController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IHttpActionResult List()
        {
            Service service = new Service();

            var students = service.GetAllStudents();
          
            return Ok(new { students });
            
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult ByClassroomName(string classroomName)
        {
            Service service = new Service();

            var students = service.GetStudentByClassRoomName(classroomName);

            return Ok(new { students });
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(StudentCreateModel model)
        {
            var studentToAdd = new Student()
            {
                Name = model.Name,
                Surname = model.Surname,
                DateOfBirth = model.DateOfBirth
            };

            Service service = new Service();

            var studentId = service.CreateStudent(studentToAdd, model.ClassroomString);

        

            return Ok(new { createdStudentId = studentId });
        }



    }
}
