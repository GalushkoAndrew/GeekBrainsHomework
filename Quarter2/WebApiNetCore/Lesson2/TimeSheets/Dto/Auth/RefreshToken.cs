using System;

namespace GeekBrains.Learn.TimeSheets.Dto.Auth
{
    /// <summary>
    /// Последний из токенов обновления
    /// </summary>
    public sealed class RefreshToken
    {
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Дата окончания действия токена
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Закончился ли срок дейтвия токена
        /// </summary>
        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
