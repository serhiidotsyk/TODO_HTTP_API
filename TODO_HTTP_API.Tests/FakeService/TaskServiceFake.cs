using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Helpers;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;

namespace TODO_HTTP_API.Tests.FakeService
{
    class TaskServiceFake : ITaskService
    {
        private readonly List<TaskModel> _taskModels;
        public TaskServiceFake()
        {
            _taskModels = new List<TaskModel>
            {
                new TaskModel
                {
                    Id = 1,
                    Title = "a",
                    Description = "a",
                    DateCreated = DateTime.Now,
                    Importance = DataAcceess.Entities.Importance.high,
                    IsCompleted = false,
                    IsDeleted = false
                },new TaskModel
                {
                    Id = 2,
                    Title = "b",
                    Description = "b",
                    DateCreated = DateTime.Now,
                    Importance = DataAcceess.Entities.Importance.high,
                    IsCompleted = false,
                    IsDeleted = false
                },
                new TaskModel
                {
                    Id = 3,
                    Title = "c",
                    Description = "c",
                    DateCreated = DateTime.Now,
                    Importance = DataAcceess.Entities.Importance.high,
                    IsCompleted = false,
                    IsDeleted = false
                },
                new TaskModel
                {
                    Id = 4,
                    Title = "d",
                    Description = "d",
                    DateCreated = DateTime.Now,
                    Importance = DataAcceess.Entities.Importance.high,
                    IsCompleted = false,
                    IsDeleted = false
                },

            };
        }

        public bool CreateUserTask(TaskModel taskModel, int[] listId)
        {
            if (taskModel == null)
                return false;
            _taskModels.Add(taskModel);
            return true;
        }

        public (bool, string) DeleteUserTask(int taskId)
        {
            _taskModels.RemoveAt(taskId);
            return (true, "deleted successfuly");
        }

        public (bool, string) DeleteUserTasks(int[] tasksId)
        {
            _taskModels.RemoveAll(x => tasksId.Contains(x.Id));
            return (true, "deleted successfuly");
        }

        public IEnumerable<TaskModel> GetOrderedTasks(QueryStringParameters taskParameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskModel> GetTasksByName(string title, int userId)
        {
            return _taskModels.Where(x => x.Title.Equals(title));
            
        }

        public TaskModel GetUserTask(int taskId)
        {
            return _taskModels.Where(x => x.Id == taskId).FirstOrDefault();
        }

        public IEnumerable<TaskModel> GetUserTasks(int userId)
        {
            return _taskModels;
        }

        public bool UpdateUserTask(TaskModel taskModel)
        {
            var toUpdate = _taskModels.IndexOf(taskModel);
            _taskModels.RemoveAt(toUpdate);
            _taskModels.Insert(toUpdate, taskModel);
            return true;
        }
    }
}
