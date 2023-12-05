using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using TaskSystemApi.Models;
using TaskSystemApi.Repository.Interface;

namespace TaskSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ITaskRepository _taskRepository;

        public TaskController(ILogger<UserController> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<List<TaskModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAll();
            _logger.LogInformation($"{tasks.Count} Tasks Found!");
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ActionResult<TaskModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            TaskModel task = await _taskRepository.GetById(id);
            _logger.LogInformation($"TaskId: {task.Id} was consulted!");
            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<TaskModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<UserModel>> AddTask([FromBody] TaskModel taskRequest)
        {
            TaskModel task = await _taskRepository.AddTask(taskRequest);
            _logger.LogInformation($"TaskId: {task.Id} has been added!");
            return Ok(task);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ActionResult<TaskModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskRequest, int id)
        {
            taskRequest.Id = id;
            TaskModel task = await _taskRepository.UpdateTask(taskRequest, taskRequest.Id);
            _logger.LogInformation($"TaskId: {task.Id} has been updated!");
            return Ok(task);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            bool hasDeleted = await _taskRepository.DeleteTask(id);
            _logger.LogInformation($"TaskId: {id} has been deleted!");
            return Ok(hasDeleted);
        }
    }
}
