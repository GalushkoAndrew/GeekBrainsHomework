namespace GeekBrains.Learn.BankAccount
{
    /// <summary>
    /// Первая версия банковского счета.
    /// Поля + методы
    /// </summary>
    public sealed class Account_v1 : AccountBase
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        private int _number = 0;

        /// <summary>
        /// Получить номер счета
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return _number;
        }

        /// <summary>
        /// Изменить номер счета
        /// </summary>
        public void SetNumber(int value)
        {
            _number = value;
        }

        /// <summary>
        /// Получить баланс
        /// </summary>
        /// <returns></returns>
        public float GetBalance()
        {
            return _balance;
        }

        /// <summary>
        /// Изменить баланс
        /// </summary>
        public void SetBalance(float value)
        {
            _balance = value;
        }

        /// <summary>
        /// Получить тип банковского счета
        /// </summary>
        /// <returns></returns>
        public AccountTypes GetAccountType()
        {
            return _accountType;
        }

        /// <summary>
        /// Изменить тип банковского счета
        /// </summary>
        public void SetAccountType(AccountTypes value)
        {
            _accountType = value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Тип счета: {GetAccountType()}, № {GetNumber()}, баланс: {GetBalance()}";
        }
    }
}
