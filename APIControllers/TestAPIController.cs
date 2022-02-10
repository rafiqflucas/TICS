using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace TICS.APIControllers
{
    /// <summary>
    /// Template class, used for testing, and troubleshooting
    /// </summary>
    [Route("api/TestAPIController")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        // GET: api/<TestAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
