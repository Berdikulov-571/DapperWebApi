using Dapper;
using DapperInWebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace DapperInWebApi.Service
{
    public class UserService
    {
        public static User GetUserById(int userId)
        {
            string? connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("userId",userId);
                User? user = connection.QueryFirstOrDefault<User>("GetUserById",dynamicParameters,commandType:CommandType.StoredProcedure);

                return user;
            }
        }

        public static IEnumerable<User> GetUsersWithYear(int startDate, int endDate)
        {
            string? connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("startDate", startDate);
                dynamicParameters.Add("endDate", endDate);
                IEnumerable<User> users = connection.Query<User>("GetUsersWithYear", dynamicParameters, commandType: CommandType.StoredProcedure);

                return users;
            }
        }

        public static List<User> GetAll(string connectionString)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                List<User> user = connection.Query<User>("getAllUsers",CommandType.StoredProcedure).ToList();

                return user;
            }
        }

        public static void Create(User user)
        {
            string? connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

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
