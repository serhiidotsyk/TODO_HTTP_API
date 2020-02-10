using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO_HTTP_API.BusinessLogic.Helpers;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;

namespace TODO_HTTP_API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("getTask")]
        public IActionResult GetTask(int taskId)
        {
            var task = _taskService.GetUserTask(taskId);
            if (task != null)
            {
                return Ok(task);
            }
            return BadRequest(new { message = "Couldnt find task" });
        }
        [HttpGet("getTaskByName")]
        public IActionResult GetTask(string title, int userId)
        {
            var tasks = _taskService.GetTasksByName(title, userId);
            if (tasks != null)
            {
                return Ok(tasks);
            }
            return BadRequest(new { message = "Couldnt find task" });
        }

        [HttpGet("getOrderedTasks")] // new QuaryStringParameters { Orderby = "your ordering query" }
        public IActionResult GetOrderedTasks(QueryStringParameters taskParameters)
        {
            if (taskParameters != null)
            {
                var res = _taskService.GetOrderedTasks(taskParameters);
                return Ok(res);
            }
            return BadRequest(new { message = "Couldnt order tasks" });
        }

        [HttpPost("createTask")]
        public IActionResult CreateTask(TaskModel taskModel, [FromQuery]int[] listId)
        {
            if (taskModel != null)
            {
                var result = _taskService.CreateUserTask(taskModel, listId);
                if (result)
                    return Ok(new { message = "Task Created" });
            }
            return BadRequest(new { message = "Couldnt create task" });
        }

        [HttpPut("updateTask")]
        public IActionResult UpdateTask(TaskModel taskUpdate)
        {
            if (taskUpdate != null)
            {
                var resut = _taskService.UpdateUserTask(taskUpdate);
                if (resut) 
                    return Ok(new { message = "Task Updated" });
            }
            return BadRequest(new { message = "Couldnt update task" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int taskId)
        {
            var (status, message) = _taskService.DeleteUserTask(taskId);

            return status ? (IActionResult)Ok() : BadRequest(new { message });
        }
        [HttpDelete]
        public IActionResult DeleteTasks([FromQuery]int[] tasksId)
        {
            var (status, message) = _taskService.DeleteUserTasks(tasksId);

            return status ? (IActionResult)Ok() : BadRequest(new { message });
        }
    }
}