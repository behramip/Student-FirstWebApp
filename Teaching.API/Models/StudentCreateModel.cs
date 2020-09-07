using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teaching.API.Models
{
    public class StudentCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string ClassroomString { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}