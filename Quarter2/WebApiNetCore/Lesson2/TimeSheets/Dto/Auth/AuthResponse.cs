namespace GeekBrains.Learn.TimeSheets.Dto.Auth
{
    /// <summary>
    /// Связка пароля и последнего токена обновления
    /// </summary>
    public sealed class AuthResponse
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Последний токен обновления
        /// </summary>
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
