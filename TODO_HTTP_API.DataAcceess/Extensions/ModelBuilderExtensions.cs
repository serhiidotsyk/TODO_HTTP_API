using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.DataAcceess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                }
            );

            modelBuilder.Entity<ToDoList>().HasData(
                new ToDoList
                {
                    Id = 1,
                    Name = "All Tasks",
                    ReturnCompleted = false,
                    UserId = 1,
                    ToDoListType = ToDoListType.smart,
                },
                new ToDoList
                {
                    Id = 2,
                    Name = "Planned Tasks",
                    ReturnCompleted = false,
                    UserId = 1,
                    ToDoListType = ToDoListType.smart,
                    
                },
                new ToDoList
                {
                    Id = 3,
                    Name = "Important Tasks",
                    ReturnCompleted = false,
                    UserId = 1,
                    ToDoListType = ToDoListType.smart,
                },
                new ToDoList
                {
                    Id = 4,
                    Name = "Today's Tasks",
                    ReturnCompleted = false,
                    UserId = 1,
                    ToDoListType = ToDoListType.smart,
                }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task{
                    Id = 1,
                    Title = "Earn 1 million dollars",
                    Description = "Do it anyway",
                    DateCreated = DateTime.Parse("10/22/2015 12:10:15 PM"),
                    Importance = Importance.high,
                    IsCompleted = false,
                    IsDeleted = false,
                }
            );
            modelBuilder.Entity<ListTask>().HasData(
                new ListTask
                {
                    ListId = 1,
                    TaskId = 1,
                }
            );
        }
    }
}
