using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student GetByName(string name);
        Student Add(Student student);
        void Delete(string student);
        bool Contains(string student);
        void EditAddLifetimeTotal(string student, int val);
        void EditAddCurrentTotal(string student, int val);
        void EditDeleteLifetimeTotal(string student, int val);
        void EditDeleteCurrentTotal(string student, int val);
        void ResetCurrentTotal();
    }
}
