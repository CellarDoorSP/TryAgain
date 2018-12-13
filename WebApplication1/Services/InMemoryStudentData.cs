using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class InMemoryStudentData : IStudentData
    {
        public InMemoryStudentData()
        {
            _students = new List<Student>
            {
                new Student{Id = 1, Name = "Katie" },
                new Student{Id = 2, Name = "Emma" },
                new Student{Id = 3, Name = "Chowder" },
                new Student{Id = 4, Name = "Craig" }

            };
        }       

        public IEnumerable<Student> GetAll()
        {
            return _students.OrderBy(s => s.Name);
        }

        List<Student> _students;
    }
}
