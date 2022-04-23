using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GeekBrains.Learn.TimeSheets.Dto.Auth;
using Microsoft.IdentityModel.Tokens;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Auth
{
    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Ключ шифрования токена
        /// </summary>
        public const string SecretCode = "Мой ключ для шифрования токена. Тридварас";

        private readonly IDictionary<string, AuthResponse> _users = new Dictionary<string, AuthResponse>()
        {
            { "test", new AuthResponse() { Password = "test" } }
        };

        /// <inheritdoc/>
        public TokenResponse Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            TokenResponse tokenResponse = new TokenResponse();
            int i = 0;
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Key, user) == 0
                    && string.CompareOrdinal(pair.Value.Password, password) == 0)
                {
                    tokenResponse.Token = GenerateJwtToken(i, 15);
                    RefreshToken refreshToken = GenerateRefreshToken(i);
                    pair.Value.LatestRefreshToken = refreshToken;
                    tokenResponse.RefreshToken = refreshToken.Token;
                    return tokenResponse;
                }
            }
            return null;
        }

        /// <inheritdoc/>
        public string RefreshToken(string token)
        {
            int i = 0;
            foreach (KeyValuePair<string, AuthResponse> pair in _users) {
                i++;
                if (string.CompareOrdinal(pair.Value.LatestRefreshToken.Token, token) == 0
                    && pair.Value.LatestRefreshToken.IsExpired is false)
                {
                    pair.Value.LatestRefreshToken =
                    GenerateRefreshToken(i);
                    return pair.Value.LatestRefreshToken.Token;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Создает токен обновления
        /// </summary>
        /// <param name="id">что-то</param>
        /// <returns>токен обновления</returns>
        public RefreshToken GenerateRefreshToken(int id)
        {
            return new RefreshToken {
                Expires = DateTime.Now.AddMinutes(360),
                Token = GenerateJwtToken(id, 360)
            };
        }

        /// <summary>
        /// Генерирует токен
        /// </summary>
        /// <param name="id">что-то</param>
        /// <param name="minutes">длительность жизни токена</param>
        /// <returns>токен?</returns>
        private string GenerateJwtToken(int id, int minutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
