using System.Collections.Generic;
using System.Web.Http;

namespace MoeLibWebLab.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("")]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [Route("")]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        [Route("")]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("")]
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        [Route("")]
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}