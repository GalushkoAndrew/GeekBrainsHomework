using GeekBrains.Learn.TimeSheets.Dto.Auth;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Auth
{
    /// <summary>
    /// Access service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Производит аутентификацию пользователя
        /// </summary>
        /// <param name="user">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>2 токена: токен обновления и токен доступа</returns>
        TokenResponse Authenticate(string user, string password);

        /// <summary>
        /// Обновляет токен доступа
        /// </summary>
        /// <param name="token">токен обновления</param>
        /// <returns>последний токен доступа</returns>
        string RefreshToken(string token);
    }
}
