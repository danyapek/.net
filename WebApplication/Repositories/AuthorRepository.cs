using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Interfaces.Repos.Dapper;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        string connectionString = "Server=DESKTOP-VFB4VGC;Database=master;User Id=danya;Password=;Trusted_Connection=True";

        private readonly ILogger<AuthorRepository> _logger;
        public AuthorRepository(ILogger<AuthorRepository> logger)
        {
            _logger = logger;
        }

        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "SelectAllAuthors";

                authors = db.Query<Author>(sql, commandType: CommandType.StoredProcedure).ToList();
            }

            return authors;
        }

        public Author GetById(int id)
        {
            Author author = null;
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var parameters = new { id = id };
                    string sql = "SelectAuhtorById";

                    author = db.Query<Author>(sql, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("GetAuthor by id: {}, error: {}", id, e.Message);
            }
            return author;
        }


        public void Add(Author author)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { name = author.Name, year = author.Year, country = author.Country };

                string sql = "InsertAuthor";
                db.Execute(sql, parameters, commandType: CommandType.StoredProcedure);

            }
        }


        public void Update(Author author)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { id = author.Id, name = author.Name, year = author.Year, country = author.Country };

                string sql = "UpdateAuthorById";
                db.Execute(sql, parameters, commandType: CommandType.StoredProcedure);

            }
        }


        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new { id = id };
                string sql = "DeleteAuthorById";
                db.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
