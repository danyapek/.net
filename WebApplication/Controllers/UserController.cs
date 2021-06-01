using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using WebApplication.Interfaces.Repos.Dapper;
using WebApplication.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private IUserRepository _repository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<Controller>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            _logger.LogDebug("Get Countries");
            return _repository.GetAll().ToList();
        }

        // GET api/<Controller>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            _logger.LogDebug("Get User by id: {}", id);
            var user = _repository.GetById(id);
            if (user != null)
                return user;
            else
                throw new NullReferenceException();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                _repository.Add(value);
                _logger.LogDebug("Add new User : {}", value.ToString());
            }
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] User value)
        {
            if (_repository.GetById(value.Id) is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                _repository.Update(value);
                _logger.LogDebug("Update User with ID : {}", value.Id);
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _repository.GetById(id);

            if (user == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _repository.Delete(id);
                _logger.LogDebug("Delete User with ID : {}", id);
            }
        }
    }
}
