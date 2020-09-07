using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingDb.Entities;
using System.Data.Entity;

namespace TeachingDb
{
    public class Service
    {
        public List<Student> GetAllStudents()
        {
            using (var db = new AppDbContext())
            {
                var aa = db.Students.Include(s => s.Classroom).ToList();

                

                return aa;
            }
        }

        public List<Student> GetStudentByClassRoomName(string classroomName)
        {
            using (var db = new AppDbContext())
            {
                var aa = db.Students.Include(s => s.Classroom).Where(s => s.Classroom.Name == classroomName).ToList();

                return aa;
            }
        }

        public int CreateStudent(Student student, string classRoomString = null)
        {
            using (var db = new AppDbContext())
            {
                Classroom classRoom;

                if (classRoomString == null)
                {
                    classRoom = db.Classrooms.First();
                }
                else
                {
                    classRoom = db.Classrooms.SingleOrDefault(c => c.Name == classRoomString);
                }

                student.Classroom = classRoom;

                db.Students.Add(student);
                db.SaveChanges();

                return student.Id;
            }
        }

        //public int CreateRequest()
    }
}
