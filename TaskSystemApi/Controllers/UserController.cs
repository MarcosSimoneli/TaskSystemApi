using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemApi.Models;
using TaskSystemApi.Repository;
using TaskSystemApi.Repository.Interface;

namespace TaskSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]        
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel>users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userRequest) 
        {
            UserModel user = await _userRepository.AddUser(userRequest);
            return Ok(user);
        }
    }
}
