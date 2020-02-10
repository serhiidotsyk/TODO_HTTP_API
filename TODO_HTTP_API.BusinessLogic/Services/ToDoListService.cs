using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.BusinessLogic.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ToDoListService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ToDoListModel GetToDoList(int listId)
        {
            ToDoListModel toDoListModel = null;
            var toDoList = _context.ToDoLists
                .Where(x => x.Id == listId)
                .Include(t => t.ListTasks)
                .ThenInclude(l => l.Task)
                .FirstOrDefault();
            if (toDoList != null)
            {
                toDoListModel = toDoListModel = _mapper.Map<ToDoListModel>(toDoList);
            };
            return toDoListModel;
        }

        public IEnumerable<ToDoListModel> GetToDoLists(int userId)
        {
            IEnumerable<ToDoListModel> toDoListModel = null;
            var toDoLists = _context.ToDoLists
                .Where(x => x.UserId == userId)
                .Include(t => t.ListTasks)
                .ThenInclude(l => l.Task)
                .ToList();
            if (toDoLists != null)
            {
                toDoListModel = _mapper.Map<IEnumerable<ToDoListModel>>(toDoLists);
            }
            return toDoListModel;
        }

        public bool CreateToDoList(ToDoListModel toDoListModel, int userId)
        {
            try
            {
                ToDoList toDoList = _mapper.Map<ToDoList>(toDoListModel);
                toDoList.UserId = userId;                

                _context.ToDoLists.Add(toDoList);
                _context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateToDoList(ToDoListModel toDoListModel)
        {
            try
            {
                var toDoList = _context.ToDoLists.Find(toDoListModel.Id);
                if (toDoList.ToDoListType == ToDoListType.smart)
                    return false;
                toDoList = _mapper.Map<ToDoList>(toDoListModel);
                _context.ToDoLists.Update(toDoList);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool UpdateToDoList(string name, int id)
        {
            try
            {
                var toDoList = _context.ToDoLists.Find(id);
                if (toDoList.ToDoListType == ToDoListType.smart)
                    return false;
                toDoList.Name = name;
                _context.ToDoLists.Update(toDoList);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }


        public (bool, string) DeleteToDoList(int listId)
        {
            try
            {
                ToDoList toDoList= _context.ToDoLists.Find(listId);
                if (toDoList.ToDoListType == ToDoListType.smart)
                    return (false, "You cannot delete smart lists");
                _context.ToDoLists.Remove(toDoList);
                _context.SaveChanges();
                return (true, "ToDoList was deleted");
            }
            catch
            {
                return (false, "Task was not deleted");
            }
        }
    }
}
