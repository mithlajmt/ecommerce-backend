using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace backendecom.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string UserId, string role);
        bool ValidateJwtToken(string token);
    }

    public class AuthService: IAuthService
    {
        private readonly string _secretkey;

        public AuthService(string secretkey)
        {
            _secretkey = secretkey;
        }

        public string GenerateJwtToken(string email, string UserId, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); //object is created to handle JWT token creation.
            var key = Encoding.ASCII.GetBytes(_secretkey); //The secret key is converted to a byte array using
            var tokenDescriptor = new SecurityTokenDescriptor //object is created, which defines the essential information for the token:
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role),  
                    new Claim(ClaimTypes.NameIdentifier, UserId)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);//creates new jwt object 
            return tokenHandler.WriteToken(token); //WriteToken method takes the JWT object and converts it into a human-readable string representation.
                                                   //This is the actual JWT token that can be sent to the client (e.g., in the response header).
        }

        public bool ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretkey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
