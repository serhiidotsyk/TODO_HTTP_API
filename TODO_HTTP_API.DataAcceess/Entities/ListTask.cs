using System;
using System.Collections.Generic;
using System.Text;

namespace TODO_HTTP_API.DataAcceess.Entities
{
    public class ListTask
    {
        public int ListId { get; set; }
        public ToDoList List { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
