using DapperInWebApi.Models;
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

        [HttpPost]
        public IActionResult CreateUser([FromForm]User user)
        {
            UserService.Create(user);

            return Ok("Created");
        }

        [HttpDelete]
        public IActionResult Delete(int UseId)
        {
            UserService.Delete(UseId);

            return Ok("Deleted");
        }
    }
}
