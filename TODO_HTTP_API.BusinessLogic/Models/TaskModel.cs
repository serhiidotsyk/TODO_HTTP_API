using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.BusinessLogic.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance? Importance { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
