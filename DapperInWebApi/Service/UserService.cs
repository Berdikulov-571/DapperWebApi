using Dapper;
using DapperInWebApi.Models;
using System.Data.SqlClient;

namespace DapperInWebApi.Service
{
    public class UserService
    {
        public static List<User> GetAll()
        {
            string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "select * from userTable";

                List<User> user = connection.Query<User>(query).ToList();

                return user;
            }
        }

    }
}
