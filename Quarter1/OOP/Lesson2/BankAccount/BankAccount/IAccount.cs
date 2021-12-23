namespace GeekBrains.Learn.BankAccount
{
    public interface IAccount
    {
        /// <summary>
        /// Тип банковского счета
        /// </summary>
        AccountTypes AccountType { get; set; }

        /// <summary>
        /// Снять деньги
        /// </summary>
        /// <param name="value">Сумма снятия</param>
        /// <returns>true - успешное снятие, false - не хватает денег на счете</returns>
        bool GetMoney(float value);

        /// <summary>
        /// Положить деньги на счет
        /// </summary>
        /// <param name="value">Сумма</param>
        /// <returns>true - счет пополнен успешно,
        /// false - криворукие программисты не предполагали, что вы положите на счет так много.
        /// Произошло переполнение какого-то числа, деньги не приняты </returns>
        bool PutMoney(float value);

        string ToString();

        /// <summary>
        /// Перевод денег с другого счета
        /// </summary>
        /// <param name="accountFrom">счет, с которого производится перевод</param>
        /// <param name="value">сумма</param>
        /// <returns>true = перевод успешен</returns>
        bool GetMoneyFromAccount(Account accountFrom, float value);
    }
}