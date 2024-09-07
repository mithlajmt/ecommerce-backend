using backendecom.Data;
using backendecom.Models.Dto;
using backendecom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Test _Test;
        public AuthController(ApplicationDbContext context , [FromServices] Test test)
        {
            _context = context;
            _Test = test;
        }

        [HttpPost("register")]
        public IActionResult Register(SignupDto signup)
        {
            if (_Test.IsTokenPresent(HttpContext))
            {
                return BadRequest("Sorry you have already logged in , you cant register now");
            }
            else
            {
                string email = signup.Email;
                return Ok(email);
            }
        }


    }
}
