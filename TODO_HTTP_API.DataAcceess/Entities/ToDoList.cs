using System;
using System.Collections.Generic;
using System.Text;

namespace TODO_HTTP_API.DataAcceess.Entities
{
    public enum ToDoListType { smart, custom };

    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ToDoListType ToDoListType { get; set; }
        public bool ReturnCompleted { get; set; }

        public ICollection<ListTask> ListTasks { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
