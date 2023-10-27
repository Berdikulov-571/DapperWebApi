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

        public static void Create(User user)
        {
            string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = $"insert into UserTable VALUES ({user.userId},'{user.firstName}','{user.lastName}')";

                connection.Query(query);
            }
        }

        public static void Delete(int UserId)
        {
            string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = $"delete from userTable where userId = {UserId}";

                connection.Query(query);
            }
        }

    }
}
