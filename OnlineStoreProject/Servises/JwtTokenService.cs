using Microsoft.IdentityModel.Tokens;
using OnlineStoreProject.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineStoreProject.Servises
{
    public class JwtTokenService
    {
        private readonly SymmetricSecurityKey _securityKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expirationMinutes;

        public JwtTokenService(AuthOptions authOptions)
        {
            _securityKey = AuthOptions.GetSymmetricSecurityKey();
            _issuer = AuthOptions.ISSUER;
            _audience = AuthOptions.AUDIENCE;
            _expirationMinutes = 20;
        }

        public string GenerateJwtToken(string userName, string userEmail)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Email, userEmail)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string AuthenticateUser(HttpContext httpContext, string userName, string userEmail)
        {
            var token = GenerateJwtToken(userName, userEmail);

            //httpContext.Response.Headers.Add("Authorization", "Bearer " + token);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Email, userEmail)
            };

            var identity = new ClaimsIdentity(claims, "jwt");
            httpContext.User = new ClaimsPrincipal(identity);

            return token;
        }
    }
}
