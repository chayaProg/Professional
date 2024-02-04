using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Intarfaces
{
    public interface IContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public  Task  save();



    }
}
