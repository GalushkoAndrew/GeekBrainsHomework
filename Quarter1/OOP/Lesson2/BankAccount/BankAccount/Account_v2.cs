namespace GeekBrains.Learn.BankAccount
{
    /// <summary>
    /// Вторая версия банковского счета.
    /// Поля + методы. Автогенерация номера счета
    /// </summary>
    public sealed class Account_v2 : AccountBase_v2
    {
        /// <summary>
        /// Получить номер счета
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return _number;
        }

        /// <summary>
        /// Генерирует номер счета
        /// </summary>
        public void GenerateNewNumber()
        {
            _number ++;
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
