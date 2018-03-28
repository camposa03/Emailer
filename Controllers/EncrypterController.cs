using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Emailer.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [Route("api/[controller]")]
    public class EncrypterController : Controller
    {
        private readonly IDataProtector protector;
        public EncrypterController(IDataProtectionProvider provider)
        {
            protector = provider.CreateProtector("Encrypter");
        }

        [HttpPost]
        public IActionResult PostAsync([FromBody] Payload payload)
        {
            Debug.WriteLine(payload.Text);

            if (string.IsNullOrEmpty(payload.Text))
            {
                return BadRequest("payload can't be null");
            }

            string decryptedPayload;
            try
            {
                decryptedPayload = protector.Unprotect(payload.Text);
            }
            catch (CryptographicException ex)
            {
                return BadRequest($"Payload is malformed: {ex.Message}");
            }
           
            //await emailer.SendAsync();
            return Ok($"Encrypter Service is up and running. Decrypted payload: {decryptedPayload}");  
        }
    }
}