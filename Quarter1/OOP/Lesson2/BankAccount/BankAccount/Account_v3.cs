using System;

namespace GeekBrains.Learn.BankAccount
{
    /// <summary>
    /// Третья версия банковского счета.
    /// Конструкторы, свойства, методы пополнения и снятия денег
    /// </summary>
    public sealed class Account_v3 : AccountBase_v2, IAccount_v3
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Account_v3() : this(0, AccountTypes.Savings)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Account_v3(float balance) : this(balance, AccountTypes.Savings)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Account_v3(AccountTypes accountType) : this(0, accountType)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Account_v3(float balance, AccountTypes accountType)
        {
            GenerateNewNumber();
            Balance = balance;
            AccountType = accountType;
        }

        /// <summary>
        /// Номер счета
        /// </summary>
        public static int Number
        {
            get { return _number; }
            private set { _number = value; }
        }

        /// <inheritdoc/>
        public float Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        /// <inheritdoc/>
        public AccountTypes AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Тип счета: {AccountType}, № {Number}, баланс: {Balance}";
        }

        /// <inheritdoc/>
        public bool GetMoney(float value)
        {
            if (Balance >= value)
            {
                Balance -= value;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool PutMoney(float value)
        {
            try
            {
                Balance += value;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Генерирует номер счета
        /// </summary>
        private static void GenerateNewNumber()
        {
            Number++;
        }
    }
}
