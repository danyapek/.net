using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Interfaces.Repos.Dapper;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        string connectionString = "Server=DESKTOP-VFB4VGC;Database=master;User Id=danya;Password=;Trusted_Connection=True";

        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users";

                users = db.Query<User>(sql).ToList();
            }

            return users;
        }

        public User GetById(int id)
        {
            User user = null;
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var parameters = new { id = id };
                    string sql = "SELECT * FROM Users WHERE id = @id";

                    user = db.Query<User>(sql, parameters).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("GetCountry by id: {}, error: {}", id, e.Message);
            }
            return user;
        }


        public void Add(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { name = user.Name, age = user.Age, email = user.Email };

                string sql = "INSERT INTO Users (name, age, email) VALUES(@name, @age, @email)";
                db.Execute(sql, parameters);

            }
        }


        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { id = user.Id, name = user.Name, age = user.Age, email = user.Email };

                string sql = "UPDATE Users SET name = @name, age = @age, email = @email WHERE id = @id";
                db.Execute(sql, parameters);

            }
        }


        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { id = id };
                string sql = "DELETE FROM Users WHERE id = @id";
                db.Execute(sql, parameters);
            }
        }
    }
}