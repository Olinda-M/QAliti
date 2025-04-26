using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] ContactModel contact)
        {
            if (contact == null)
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.your-email-server.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your-email@example.com", "your-password"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(contact.Email),
                    Subject = "Wiadomość z formularza kontaktowego",
                    Body = $"Imię: {contact.Name}\nWiadomość:\n{contact.Message}",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add("your-email@example.com");

                await smtpClient.SendMailAsync(mailMessage);
                return Ok("Wiadomość została wysłana.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Wystąpił błąd podczas wysyłania wiadomości.");
            }
        }
    }

    public class ContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
