namespace backendecom.Services
{
    public class Test
    {
        public bool IsTokenPresent(HttpContext context) //is a fundamental class in ASP.NET Core that represents the current HTTP request and response within a web application.
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            return token != null;  //if token is not null it returns true .if token is null it return false
        }

    }
}
