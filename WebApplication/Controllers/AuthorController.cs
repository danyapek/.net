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
        [Route("api/authors")]
        [ApiController]
        public class AuthorController
        {
            private readonly ILogger<AuthorController> _logger;
            private IAuthorRepository _repository;

            public AuthorController(ILogger<AuthorController> logger, IAuthorRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }


            // GET: api/<Controller>
            [HttpGet]
            public ActionResult<IEnumerable<Author>> Get()
            {
                _logger.LogDebug("Get Authors");
                return _repository.GetAll().ToList();
            }

            // GET api/<Controller>/5
            [HttpGet("{id}")]
            public ActionResult<Author> Get(int id)
            {
                _logger.LogDebug("Get Author by id: {}", id);
                var author = _repository.GetById(id);
                if (author != null)
                    return author;
                else
                    throw new NullReferenceException();
            }

            // POST api/<ValuesController>
            [HttpPost]
            public void Post([FromBody] Author value)
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _repository.Add(value);
                    _logger.LogDebug("Add new Author : {}", value.ToString());
                }
            }


            // PUT api/<ValuesController>/5
            [HttpPut("{id}")]
            public void Put([FromBody] Author value)
            {
                if (_repository.GetById(value.Id) is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _repository.Update(value);
                    _logger.LogDebug("Update Author with ID : {}", value.Id);
                }

            }

            // DELETE api/<ValuesController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            Author author = _repository.GetById(id);

                if (author == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    _repository.Delete(id);
                    _logger.LogDebug("Delete Author with ID : {}", id);
                }
            }
        }
}
