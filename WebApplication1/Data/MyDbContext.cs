using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
