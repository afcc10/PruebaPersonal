using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaPersonal.Helpers
{
    public class JWTHelper
    {
        private readonly byte[] secret;
        public JWTHelper(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }

        public string createToken(string userName)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,userName));

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret),SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
