using Common.Entity;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Repository.Entities;
using Services.Intaefaces;
 using MailKit.Net.Smtp;
 using System.Net;
 using System.Net.Mail;
 using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Org.BouncyCastle.Ocsp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UserController : ControllerBase
   {
       private readonly IService<UserDto> _service;
       private IConfiguration configuration;


        public UserController(IService<UserDto> service, IConfiguration configuration1)
        { 
            _service = service;
            this.configuration = configuration1;

        }

        private async Task<UserDto> GetUserByEmail_Id(string email, string identity)
        {
            List<UserDto> users = await _service.GetAll();

            // Find the user with the matching email and identity
            UserDto user = users.FirstOrDefault(u => u.Email == email && u.Identity == identity);

            // If user is null, throw an InvalidOperationException
            if (user == null)
            {
                throw new InvalidOperationException("Invalid email or identity.");
            }

            return user;
        }

        private string Generate(UserDto user)
        {
            //מפתח להצפנה-מהקובץ appsettings
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //אלגוריתם להצפנה
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //אלו שדות להצפין
            var claims = new[] {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.GivenName,user.Name),
            new Claim("IdentityDocument", user.Identity),
            new Claim("PhoneIdentifier", user.Phone),

            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // החלף את Id עם תכונת מזהה המשתמש בפועל
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims,
                //תוקף ההזמנה
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var UserClaim = identity.Claims;
                if (userId != null)
                {
                    return new UserDto()
                    {
                        Id = int.Parse(userId),
                        //Id=UserClaim.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value,
                        Name = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                        Email = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                        Identity = UserClaim.FirstOrDefault(x => x.Type == "IdentityDocument")?.Value,
                        Phone = UserClaim.FirstOrDefault(x => x.Type == "PhoneIdentifier")?.Value,

                    };
                }
            }
            return null;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
          return await _service.GetAll();
        }
        
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get1(int id)
        {
         return await _service.GetById(id);
        }
       


        /* // POST api/<UserController>
        [HttpPost("verifyFirst")]
        public async Task<ActionResult> signUp([FromBody] UserDto user)
        {
        preuser=user;
        Random random = new Random();
        int code = random.Next(1000, 9999);
        precode=code;
        string codeString = code.ToString();

        try
        {
          using (var client = new SmtpClient())
          {
              await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
              await client.AuthenticateAsync("finder4u100@gmail.com", "lsex ursz azsl mgss");

                     var message = new MimeMessage();
              message.From.Add(new MailboxAddress("proFinder", "finder4u100@gmail.com"));
              message.To.Add(MailboxAddress.Parse(user.Email));
              message.Subject = "enter the password to proFinder-app";
              message.Body = new TextPart("plain")
              {
                  Text = $"Enter the 4 digits on the site for verification: {codeString}"
              };
              var builder = new BodyBuilder();

              var htmlContent = System.IO.File.ReadAllText("Html/htmlValidationUser.html");


              builder.HtmlBody = htmlContent;


              builder.HtmlBody = htmlContent.Replace("{code}", codeString);


              message.Body = builder.ToMessageBody();

              await client.SendAsync(message);
              await client.DisconnectAsync(true);
              *//*user.Code= code;*/
        /*                    return Ok(await _service.Add(user));
        *//*
                        }
                        return Ok("mail is correct connect successfully");
                       *//* Console.WriteLine("Mail Sent Successfully!");*//*
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email: {ex.Message}");
                        return BadRequest(ex);
                   }
                   *//* return Ok(await _service.Add(user));*//*
               }

                [HttpPost]
                public async Task<ActionResult> PostEmailCode([FromBody] int code)
                {
                    if (code == precode)
                    {
                         return Ok(await _service.Add(preuser));
                    }
                    else
                    {
                        return BadRequest("the code is not correct");
                    }

                }
        */

        /*    [HttpPost("verifyFirst")]
        public async Task<ActionResult> SignUp([FromBody] UserDto user)
        {
            try
            {
                Random random = new Random();
                int code = random.Next(1000, 9999);
                string codeString = code.ToString();
                *//*TempData["tempcode"] = codeString; // שמירת ערך ב- TempData*//*
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("finder4u100@gmail.com", "lsex ursz azsl mgss");

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("proFinder", "finder4u100@gmail.com"));
                    message.To.Add(MailboxAddress.Parse(user.Email));
                    message.Subject = "enter the password to proFinder-app";
                    message.Body = new TextPart("plain")
                    {
                        Text = $"Enter the 4 digits on the site for verification: {codeString}"
                    };
                    var builder = new BodyBuilder();

                    var htmlContent = System.IO.File.ReadAllText("Html/htmlValidationUser.html");

                    builder.HtmlBody = htmlContent;
                    builder.HtmlBody = htmlContent.Replace("{code}", codeString);

                    message.Body = builder.ToMessageBody();

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    return Ok(codeString);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to send email: {ex.Message}");
            }
        }*/


        [HttpPost("verifyEmail")]
        public async Task<ActionResult> VerifyEmail([FromBody] string email)
        {
            try
            {
                Random random = new Random();
                int code = random.Next(1000, 9999);
                string codeString = code.ToString();
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("finder4u100@gmail.com", "lsex ursz azsl mgss");

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("proFinder", "finder4u100@gmail.com"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.Subject = "enter the password to proFinder-app";
                    message.Body = new TextPart("plain")
                    {
                        Text = $"Enter the 4 digits on the site for verification: {codeString}"
                    };
                    var builder = new BodyBuilder();

                    var htmlContent = System.IO.File.ReadAllText("Html/htmlValidationUser.html");

                    builder.HtmlBody = htmlContent;
                    builder.HtmlBody = htmlContent.Replace("{code}", codeString);

                    message.Body = builder.ToMessageBody();

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    return Ok(codeString);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to send email: {ex.Message}");
            }
        }

        [HttpPost("signUp")]
        public async Task<ActionResult> SignUp([FromBody] UserDto user)
        {
            return Ok(await _service.Add(user));

        }






        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto user)
        {
            try
            {
                await _service.Update(id, user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
           /* await _service.Update(id, user);*/
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        //לשים לב שמקבל פחות נתונים מה שמחזיר זה בעיה?
        [HttpPost("/login")]
        public async Task<ActionResult> Login([Required, EmailAddress] string email, [Required] string identity)
        {

            UserDto u = await GetUserByEmail_Id(email, identity);
            if (u != null)
            {
                var token = Generate(u);
                return Ok(token);
            }
            return NotFound("user not found");
        }
   }   
}
