using api2.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<AssignTasks> Assigntasks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<api2.models.Task> Tasks { get; set; }
       
    }
}
