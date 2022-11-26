using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtSample
{
    internal class UserService
    {
        private IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"root1", "test"}, // 0
            {"root2", "test"}, // 1
            {"root3", "test"}, // 2
            {"root4", "test"}  // 3
        };

        private const string SecretCode = "kYp3s6v9y/B?E(H+";

        public string Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            int i = 0;
            foreach (KeyValuePair<string, string> pair in _users)
            {
                if (string.CompareOrdinal(pair.Key, user) == 0 &&
                string.CompareOrdinal(pair.Value, password) == 0)
                {
                    return GenerateJwtToken(i);
                }
                i++;
            }

            return null;
        }

        private string GenerateJwtToken(int id)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(15);
            securityTokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())

            });
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

    }
}
