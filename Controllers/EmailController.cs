using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
        private readonly Encrypter encrypter;
        public EmailController(IEmailer emailer, Encrypter encrypter)
        {
            this.encrypter = encrypter;
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
            //email.CustomerInformation = encrypter.Protect(email.CustomerInformation);
            Debug.WriteLine(email.CustomerInformation);
            try
            {
                await emailer.SendAsync(email);
            }
            catch (SmtpException e)
            {
                return Ok("Received request but couldn't send emails");
            }
            catch (Exception e)
            {
                return Ok("Sorry, having trouble sending e-mail.");
            }

            return Ok("Email successfully sent");
        }
    }
}
