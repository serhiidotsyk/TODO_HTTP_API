using System;
using System.Collections.Generic;
using System.Text;

namespace TODO_HTTP_API.DataAcceess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDoList> Lists { get; set; }
    }
}
