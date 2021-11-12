namespace GeekBrains.Learn.BankAccount
{
    public interface IAccount_v3
    {
        /// <summary>
        /// Тип банковского счета
        /// </summary>
        AccountTypes AccountType { get; set; }

        /// <summary>
        /// Баланс
        /// </summary>
        float Balance { get; set; }

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
    }
}