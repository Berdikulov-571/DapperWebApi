using DapperInWebApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperInWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudentByID(int studentId)
        {
            var res = UserService.GetUserById(studentId);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetUsersWithYear(int startDate, int endDate)
        {
            var res = UserService.GetUsersWithYear(startDate, endDate);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var res = UserService.GetAll();

            return Ok(res);
        }
    }
}
