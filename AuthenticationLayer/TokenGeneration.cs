using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationLayer
{
    public class TokenGeneration : ITokenGeneration
    {
        public string GenerateJSONToken(LoginModel model)
        {
            var key = "TempKeyPutInSecrets";
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {

                new(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new(ClaimTypes.Name, model.Name),
                new(ClaimTypes.Email, model.Email),
                new(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
