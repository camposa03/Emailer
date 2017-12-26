using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Emailer.Models;
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
        public IActionResult GetAsync()
        {
            //await emailer.SendAsync();
            return Ok("Service is up and running...");
     
        }

        // GET api/email/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/email
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]EmailInputModel email)
        {
            Debug.WriteLine(email.CustomerInformation);
            await emailer.SendAsync(email);
            return Ok(email.CustomerInformation);
        }
    }
}
