 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemApi.Models;

namespace TaskSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUsers() 
        {
            return Ok();
        }
    }
}
