namespace GeekBrains.Learn.TimeSheets.Dto.Auth
{
    /// <summary>
    /// Токены, получаемые в результате аутентификации
    /// </summary>
    public sealed class TokenResponse
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
