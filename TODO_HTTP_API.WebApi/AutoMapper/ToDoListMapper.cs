using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.WebApi.AutoMapper
{
    public class ToDoListMapper: Profile
    {
        public ToDoListMapper()
        {
            CreateMap<ToDoList, ToDoListModel>()
                .ForMember(dest => dest.Tasks, opt => opt
                    .MapFrom(f => f.ListTasks
                        .Select(t => t.Task)
                            .ToList())); ;
            CreateMap<ToDoListModel, ToDoList>();
        }
    }
}
