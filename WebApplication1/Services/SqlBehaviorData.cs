using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SqlBehaviorData : IBehaviorData
    {
        private MyDbContext _context;

        public SqlBehaviorData(MyDbContext context)
        {
            _context = context;
        }

        public Behavior Add(Behavior behavior)
        {
            _context.Behavior.Add(behavior);
            _context.SaveChanges();
            return behavior;
        }

        //public void Delete(string student, string behavior)
        //{
        //    Behavior removeBeavior = GetByName()
        //}

        public Behavior Get(int id)
        {
            return _context.Behavior.FirstOrDefault(s => s.Id == id);
        }

        //public Behavior GetByName(string behavior, string student)
        //{
        //    List<Behavior> behaviorsMatched = _context.Behaviors.Where(s => s.)
        //    return _context.Behaviors.FirstOrDefault(b => b.Name == behavior && s => )
        //}

        public IEnumerable<Behavior> GetAll()
        {
            return _context.Behavior;
        }
    }
}
