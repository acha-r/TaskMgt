using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TaskMgt.Models;
using TaskMgt.Services;

namespace TaskMgt.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService service)
        {
            _taskService = service;
        }

        [AllowAnonymous]
        [HttpGet("get-tasks")]
        public IActionResult Get()
        {
            return Ok(_taskService.GetTasks());
        }

        [HttpPost("create-task")]
        public IActionResult Post([FromBody] Tasks task)
        {
            return Ok(_taskService.CreateTask(task));
        }

        [HttpDelete("delete-task")]
        public void Delete(int taskId)
        {
            _taskService.DeleteTask(taskId);
        }

        [HttpPut("assign-task")]
        public IActionResult Put(int taskId, string email)
        {
            return Ok(_taskService.AssignTask(taskId, email));
        }
    }
}
