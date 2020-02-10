using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;

namespace TODO_HTTP_API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet("getToDoList")]
        public IActionResult GetToDoList(int listId)
        {
            var toDoList = _toDoListService.GetToDoList(listId);
            if (toDoList != null)
            {
                return Ok(toDoList);
            }
            return BadRequest(new { message = "Couldnt find list" });
        }

        [HttpGet("getToDoLists")]
        public IActionResult GetToDoLists(int userId)
        {
            var toDoList = _toDoListService.GetToDoLists(userId);
            if (toDoList != null)
            {
                return Ok(toDoList);
            }
            return BadRequest(new { message = "Couldnt find lists" });
        }

        [HttpPost("createToDoList")]
        public IActionResult CreateToDoList(ToDoListModel toDoListModel, int userId)
        {
            var result = _toDoListService.CreateToDoList(toDoListModel, userId);
            if (result)
            {
                return Ok(new { message = "ToDoList created" });
            }
            return BadRequest(new { message = "Couldnt create list" });
        }
        [HttpPut("updateToDoListByModel")]
        public IActionResult UpdateToDoList(ToDoListModel toDoListModel)
        {
            var toDoList = _toDoListService.UpdateToDoList(toDoListModel);
            if (toDoList)
            {
                return Ok(new { message = "ToDoList updated" });
            }
            return BadRequest(new { message = "Couldnt update list" });
        }
        [HttpPut("updateToDoListByName")]
        public IActionResult UpdateToDoList(string name, int id)
        {
            var toDoList = _toDoListService.UpdateToDoList(name, id);
            if (toDoList)
            {
                return Ok(new { message = "ToDoList updated" });
            }
            return BadRequest(new { message = "Couldnt update list" });
        }

        [HttpDelete("deleteToDoList")]
        public IActionResult DeleteToDoList(int id)
        {
            var (status, message) = _toDoListService.DeleteToDoList(id);

            return status ? (IActionResult)Ok() : BadRequest(new { message });
        }

}
}