using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emailer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailer emailer;
        public EmailController(IEmailer emailer)
        {
            this.emailer = emailer;
        }
        // GET api/email
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            await emailer.SendAsync();
            return new string[] { "value1", "value2" };
     
        }

        // GET api/email/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/email
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
    }
}
