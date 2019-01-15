using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SqlStudentData : IStudentData
    {
        private MyDbContext _context;

        public SqlStudentData(MyDbContext context)
        {
            _context = context;
        }

        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void Delete(string student)
        {
            Student removeStudent = GetByName(student);
            if (removeStudent != null)
            {
                _context.Students.Remove(removeStudent);
                _context.SaveChanges();
            }
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student GetByName(string name)
        {
            return _context.Students.FirstOrDefault(s => s.Name == name);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.OrderBy(s => s.Name);
        }
    }
}
