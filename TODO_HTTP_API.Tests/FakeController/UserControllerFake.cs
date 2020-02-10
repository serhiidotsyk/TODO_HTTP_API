using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.Tests.FakeService;
using TODO_HTTP_API.WebApi.Controllers;
using Xunit;

namespace TODO_HTTP_API.Tests.FakeController
{
    public class UserControllerFake
    {
        UserController _controller;
        IUserService _userService;
        public UserControllerFake()
        {
            _userService = new UserServiceFake();
            _controller = new UserController(_userService);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetUsers();
            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllResult()
        {
            //Act
            var okResult = _controller.GetUsers();

            //Assert
            Assert.IsType<OkObjectResult>(okResult);

            var okObjectResult = okResult as OkObjectResult;
            var items = Assert.IsType<List<UserModel>>(okObjectResult.Value);
        }

    }
}
