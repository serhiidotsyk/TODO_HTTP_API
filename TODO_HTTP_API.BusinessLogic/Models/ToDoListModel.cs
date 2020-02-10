using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.BusinessLogic.Models
{
    public class ToDoListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ToDoListType? ToDoListType { get; set; }
        public bool ReturnCompleted { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
