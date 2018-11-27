using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomMiddlewareExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
        // GET api/values/error
        [HttpGet("error")]
        public IEnumerable<string> GetError()
        {
            throw new Exception();
        }

        // GET api/values/unauthorized
        [HttpGet("unauthorized")]
        public IEnumerable<string> GetUnauthorizedError()
        {
            throw new UnauthorizedAccessException();
        }

        // GET api/values/notfound
        [HttpGet("notfound")]
        public IEnumerable<string> GetNotFoundError()
        {
            throw new NullReferenceException();
        }

        // GET api/values/stackoverflow
        [HttpGet("stackoverflow")]
        public IEnumerable<string> GetStackOverflowError()
        {
            throw new StackOverflowException();
        }
    }
}
