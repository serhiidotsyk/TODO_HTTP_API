using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.DataAcceess.Entities;
using TODO_HTTP_API.DataAcceess.Extensions;

namespace TODO_HTTP_API.DataAcceess
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure ListId and TaskId as the composite key
            modelBuilder.Entity<ListTask>().HasKey(lt => new { lt.ListId, lt.TaskId });

            //Seed Data
            modelBuilder.Seed();
        }

        //entities
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ListTask> ListTasks { get; set; }
    }
}
