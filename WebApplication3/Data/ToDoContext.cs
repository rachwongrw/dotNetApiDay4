using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
                // manually adding the id - because we're seeding the data. as opposed to db.Add(ToDo)....
                new { Id = 1, Description = "Bake Cookies", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now }, 
                new { Id = 2, Description = "Eat Cookies", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now },
                new { Id = 3, Description = "Run around the block", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now }
                );
        }
    }
}
