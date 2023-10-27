using DapperInWebApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperInWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(UserService.GetAll());
        }
    }
}
