using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Helpers;
using TODO_HTTP_API.BusinessLogic.Helpers.Interfaces;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.BusinessLogic.Services
{
    public enum SmartListTypes { AllTasks = 1, PlannedTasks, ImportantTasks, TodaysTasks };
    public class TaskService : ITaskService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ISortHelper<Task> _helper;
        public TaskService(ApplicationContext context, IMapper mapper, ISortHelper<Task> helper)
        {
            _context = context;
            _mapper = mapper;
            _helper = helper;
        }
        public TaskModel GetUserTask(int taskId)
        {
            TaskModel taskModel = null;
            var task = _context.Tasks.Where(x => x.IsDeleted != true).FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                taskModel = _mapper.Map<TaskModel>(task);
            }
            return taskModel;
        }

        public IEnumerable<TaskModel> GetUserTasks(int listId)
        {
            return null;
        }

        public IEnumerable<TaskModel> GetOrderedTasks(QueryStringParameters taskParameters)
        {
            IEnumerable<TaskModel> taskModels = null;
            if(taskParameters != null)
            {
                var temp = _context.Tasks.Where(x => x.IsCompleted == false);
                temp = _helper.ApplySort(temp, taskParameters);
                taskModels = _mapper.Map<IEnumerable<TaskModel>>(temp);
            }
            return taskModels;
        }

        public IEnumerable<TaskModel> GetTasksByName(string title, int userId)
        {
            IEnumerable<TaskModel> taskModels = null;
            if (!string.IsNullOrWhiteSpace(title))
            {
                var list = _context.ToDoLists
                    .Include(t => t.ListTasks)
                    .ThenInclude(l => l.Task)
                    .SingleOrDefault(x =>
                    x.UserId == userId &&
                    x.Name.Equals("All Tasks") &&
                    x.ToDoListType == ToDoListType.smart);
                var temp = list.ListTasks.Select(r => r.Task).Where(t => t.Title.Equals(title));
                taskModels = _mapper.Map<IEnumerable<TaskModel>>(temp);
            }
            return taskModels;
        }

        public bool CreateUserTask(TaskModel taskModel, int[] listsId)
        {
            try
            {
                var temp = _context.ToDoLists.Where(l => listsId.Contains(l.Id));
                if (!ListTypeHelper(listsId, taskModel, temp.ToList()))
                    return false;
                Task task = new Task();

                task = _mapper.Map<TaskModel, Task>(taskModel, cfg =>
                     cfg.AfterMap((src, dest) =>
                     {
                         dest.Importance = taskModel.Importance == null ? Importance.normal : taskModel.Importance.Value;
                     }));

                _context.Tasks.Add(task);
                _context.SaveChanges();

                if (listsId == null || listsId.Length <= 0)
                {
                    ListTask listTask = new ListTask
                    {
                        ListId = 1,
                        TaskId = task.Id
                    };
                    _context.ListTasks.Add(listTask);
                    _context.SaveChanges();
                }
                else
                {
                    List<ListTask> listTasks = new List<ListTask>();
                    for (int i = 0; i < listsId.Length; i++)
                    {
                        listTasks.Add(new ListTask
                        {
                            ListId = listsId[i],
                            TaskId = task.Id
                        });
                    }
                    _context.AddRange(listTasks);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateUserTask(TaskModel taskUpdate)
        {
            try
            {
                var task = _context.Tasks.Find(taskUpdate.Id);
                task = _mapper.Map<Task>(taskUpdate);
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public (bool, string) DeleteUserTask(int taskId)
        {
            try
            {
                Task task = _context.Tasks.Find(taskId);
                if (task.IsCompleted)
                {
                    task.IsDeleted = true;
                    _context.Tasks.Update(task);
                    _context.SaveChanges();
                    return (true, "Task was soft-deleted");
                }
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return (true, "Task was deleted");
            }
            catch
            {
                return (false, "Task was not deleted");
            }
        }

        public (bool, string) DeleteUserTasks(int[] tasksId)
        {
            try
            {
                Task task = null;
                for (int i = 0; i < tasksId.Length; i++)
                {
                    task = _context.Tasks.Find(tasksId[i]);
                    if (task.IsCompleted)
                    {
                        task.IsDeleted = true;
                        _context.Tasks.Update(task);
                        _context.SaveChanges();
                    }
                    else
                    {
                        _context.Tasks.Remove(task);
                        _context.SaveChanges();
                    }
                }
                return (true, "Tasks were deleted");
            }
            catch
            {
                return (false, "Tasks were not deleted");
            }
        }

        private bool ListTypeHelper(int[] listsId, TaskModel taskModel, List<ToDoList> toDoList)
        {
            if (listsId.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                return false;
            }
            int counter = 0;
            for (int i = 0; i < toDoList.Count; i++)
            {
                toDoList[i].ToDoListType = ToDoListType.custom;
                counter++;
            }
            if (counter > 1)
                return false;
            if (listsId.Contains((int)SmartListTypes.ImportantTasks) && taskModel.Importance != Importance.high)
                return false;
            if (listsId.Contains((int)SmartListTypes.PlannedTasks) && taskModel.DueDate == null)
                return false;
            if (listsId.Contains((int)SmartListTypes.TodaysTasks) && taskModel.DueDate != DateTime.Today)
                return false;
            return true;
        }
    }
}
