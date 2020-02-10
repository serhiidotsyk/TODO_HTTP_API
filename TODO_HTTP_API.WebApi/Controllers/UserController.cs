using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO_HTTP_API.BusinessLogic;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Services;

namespace TODO_HTTP_API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            if(users != null)
            {
                return Ok(users);
            }
            return BadRequest(new { message = "Couldnt find users" });
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(new { message = "Couldnt find user" });
        }
    }
}