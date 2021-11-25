namespace GeekBrains.Learn.BankAccount
{
    /// <summary>
    /// Базовые поля счета, общие для всех версий счетов
    /// </summary>
    public abstract class AccountBase
    {
        /// <summary>
        /// Баланс
        /// </summary>
        protected float _balance = 0;

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        protected AccountTypes _accountType = AccountTypes.Savings;
    }
}
