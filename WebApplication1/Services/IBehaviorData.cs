using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBehaviorData
    {
        IEnumerable<Behavior> GetAll();
        Behavior Get(int id);
        //Behavior GetByName(string name, string studentName);
        Behavior Add(Behavior behavior);
        //void Delete(string student, string behavior);
    }
}
