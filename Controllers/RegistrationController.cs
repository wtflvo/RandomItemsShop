using Microsoft.AspNetCore.Mvc;
using RandomItemsShop.Models;
using RandomItemsShop.DbConnectors;

namespace RandomItemsShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        
        

        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<string> AddUser([FromBody] UsersTable user)
        {
            DbChanger dbChanger = new ();
            
            if (user != null)
            {
               string result = await dbChanger.InsertUser(user);
                
                return result;
            }
            else { throw new Exception("Adding new user to DB went wrong"); }

        }

//        public async Task SendEmail() { 
//        var apiKey = "YOUR_SENDGRID_API_KEY";
//        var client = new SendGridClient(apiKey);

//        // Build email message
//        var msg = new SendGridMessage();
//        msg.SetFrom(new EmailAddress("noreply@yourdomain.com", "Your Application"));
//msg.AddTo(new EmailAddress(user.Email, user.Name));
//msg.SetSubject("Please verify your email address");
//msg.AddContent(MimeType.Html, "<p>Thank you for signing up! Please click the following link to verify your email address:</p>");
//msg.AddContent(MimeType.Html, $"<a href=\"http://localhost:5262/verify-email?token={verificationToken}\">Verify Email Address</a>");

//// Send email
//var response = await client.SendEmailAsync(msg);
//if (response.StatusCode == HttpStatusCode.Accepted)
//{
//    // Email sent successfully
//}
//else
//{
//    // Email failed to send
//}
//        }

    }
}