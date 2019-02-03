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

        public Student GetByName(string name)
        {
            return _context.Students.FirstOrDefault(s => s.StudentName == name);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.OrderBy(s => s.StudentName);
        }

        public bool Contains(string student)
        {
            return _context.Students.ToList().Contains(GetByName(student));
        }

        public void EditAddLifetimeTotal(string student, int val)
        {
            if(Contains(student))
            {
                GetByName(student).LifetimeTotal += val;
                _context.SaveChanges();
            }
        }

        public void EditAddCurrentTotal(string student, int val)
        {
            if (Contains(student))
            {
                GetByName(student).CurrentTotal += val;
                _context.SaveChanges();
            }
        }

        public void EditDeleteLifetimeTotal(string student, int val)
        {
            if (Contains(student))
            {
                GetByName(student).LifetimeTotal -= val;
                _context.SaveChanges();
            }
        }
  
        public void EditDeleteCurrentTotal(string student, int val)
        {
            if (Contains(student))
            {
                GetByName(student).CurrentTotal -= val;
                _context.SaveChanges();
            }
        }

        public void ResetCurrentTotal()
        {
            foreach(var student in _context.Students)
            {
                student.CurrentTotal = 0;
            }

            _context.SaveChanges();
        }
    }
}
