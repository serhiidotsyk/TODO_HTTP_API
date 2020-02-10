using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.WebApi.AutoMapper
{
    public class TaskMapper: Profile
    {
        public TaskMapper()
        {
            CreateMap<TaskModel, Task>();
            CreateMap<Task, TaskModel>();
        }
    }
}
