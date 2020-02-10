using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Models;

namespace TODO_HTTP_API.BusinessLogic.Interfaces
{
    public interface IToDoListService
    {
        ToDoListModel GetToDoList(int listId);
        IEnumerable<ToDoListModel> GetToDoLists(int userId);
        bool CreateToDoList(ToDoListModel toDoListModel, int userId);
        bool UpdateToDoList(ToDoListModel toDoListModel);
        bool UpdateToDoList(string name, int id);
        (bool, string) DeleteToDoList(int id);
    }
}
