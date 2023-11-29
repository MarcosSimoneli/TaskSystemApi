using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using TaskSystemApi.Models;
using TaskSystemApi.Repository.Interface;

namespace TaskSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<List<UserModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAll();
            _logger.LogInformation($"{users.Count} Users Found!");
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ActionResult<UserModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            _logger.LogInformation($"UserId: {user.Id} was consulted!");
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<UserModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userRequest)
        {
            UserModel user = await _userRepository.AddUser(userRequest);
            _logger.LogInformation($"UserId: {user.Id} has been added!");
            return Ok(user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ActionResult<UserModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userRequest, int id)
        {
            userRequest.Id = id;
            UserModel user = await _userRepository.UpdateUser(userRequest, userRequest.Id);
            _logger.LogInformation($"UserId: {user.Id} has been updated!");
            return Ok(user);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool hasDeleted = await _userRepository.DeleteUser(id);
            _logger.LogInformation($"UserId: {id} has been deleted!");
            return Ok(hasDeleted);
        }
    }
}
