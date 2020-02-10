using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.Tests.FakeService;
using TODO_HTTP_API.WebApi.Controllers;
using Xunit;

namespace TODO_HTTP_API.Tests.FakeController
{
    public class TaskControllerFake
    {
        TaskController _controller;
        ITaskService _taskService;
        public TaskControllerFake()
        {
            _taskService = new TaskServiceFake();
            _controller = new TaskController(_taskService);
        }
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            TaskModel pass_null_object = null;

            //Act
            var badResponse = _controller.CreateTask(pass_null_object, new int[] { 1 });

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}
