using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emailer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            var emailer = new Mailer();
            await emailer.SendAsync();
            return new string[] { "value1", "value2" };
     
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
    }
}
