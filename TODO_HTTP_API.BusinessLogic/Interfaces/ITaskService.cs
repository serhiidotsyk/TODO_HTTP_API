using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Helpers;
using TODO_HTTP_API.BusinessLogic.Models;

namespace TODO_HTTP_API.BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetUserTasks(int userId);
        TaskModel GetUserTask(int taskId);
        IEnumerable<TaskModel> GetTasksByName(string title, int userId);
        IEnumerable<TaskModel> GetOrderedTasks(QueryStringParameters taskParameters);
        bool CreateUserTask(TaskModel taskModel, int[] listId);
        bool UpdateUserTask(TaskModel taskModel);
        (bool, string) DeleteUserTask(int taskId);
        (bool, string) DeleteUserTasks(int[] tasksId);
    }
}
