using System;
using System.Collections.Generic;
using System.Text;

namespace TODO_HTTP_API.DataAcceess.Entities
{
    public enum Importance { low, normal, high};
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Importance { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ListTask> ListTasks { get; set; }
    }
}
