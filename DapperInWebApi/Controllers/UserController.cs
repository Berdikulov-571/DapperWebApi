using Dapper;
using DapperInWebApi.Models;
using DapperInWebApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
        public IActionResult CreateUser([FromForm] User user)
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

        [HttpGet]
        public async ValueTask<IActionResult> GetALlMultipleQueryUsers()
        {
            string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"select * from userTable; select * from persons;";

                var users = await connection.QueryMultipleAsync(query);

                var firstTable = users.ReadAsync<User>().Result;

                var secondTable = users.ReadAsync<Person>().Result;

                return Ok(new
                {
                    Users = firstTable,
                    Persons = secondTable
                });
            }
        }
    }
}
