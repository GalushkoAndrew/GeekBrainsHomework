using System;

namespace GeekBrains.Learn.BankAccount
{
    /// <summary>
    /// Банковский счет
    /// </summary>
    public sealed class Account : IAccount
    {
        /// <summary>
        /// Баланс
        /// </summary>
        private float _balance = 0;

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        private AccountTypes _accountType = AccountTypes.Savings;

        /// <summary>
        /// Номер последнего созданного счета
        /// </summary>
        private static int _number = 0;

        /// <summary>
        /// Номер счета
        /// </summary>
        private int _numberCurrent = 0;

        /// <summary>
        /// ctor
        /// </summary>
        public Account() : this(0, AccountTypes.Savings)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Account(float balance) : this(balance, AccountTypes.Savings)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Account(AccountTypes accountType) : this(0, accountType)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Account(float balance, AccountTypes accountType)
        {
            GenerateNewNumber();
            _numberCurrent = _number;
            Balance = balance;
            AccountType = accountType;
        }

        /// <summary>
        /// Номер счета
        /// </summary>
        public int Number
        {
            get { return _numberCurrent; }
            private set { _numberCurrent = value; }
        }

        /// <summary>
        /// Баланс
        /// </summary>
        private float Balance
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

        /// <inheritdoc/>
        public bool GetMoneyFromAccount(Account accountFrom, float value)
        {
            if (value < 0)
            {
                Console.WriteLine("Попытка взлома через перевод отрицательной суммы. Операция отменена.");
                return false;
            }

            float transferedValue;
            if (accountFrom.GetMoney(value))
            {
                transferedValue = value;
            }
            else
            {
                Console.WriteLine("Не удалось снять сумму со счета акаунта-источника");
                return false;
            }

            if (PutMoney(transferedValue))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Не удалось зачислить снятую сумму на счет акаунта-получателя");
                if (!accountFrom.PutMoney(transferedValue))
                {
                    Console.WriteLine("Не удалось вернуть снятую сумму на счет акаунта-источника. Деньги пропали, обратитесь в банк.");
                }

                return false;
            }
        }

        public static bool operator ==(Account ac1, Account ac2)
        {
            if (ac1 is null || ac2 is null)
            {
                return false;
            }

            if (ac1.AccountType == ac2.AccountType &&
                ac1.Balance == ac2.Balance &&
                ac1.Number)
            {

            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return this == (Account)obj;
        }

        public static bool operator !=(Account ac1, Account ac2)
        {
            return !(ac1 == ac2);
        }

        /// <summary>
        /// Генерирует номер счета
        /// </summary>
        private static void GenerateNewNumber()
        {
            _number++;
        }
    }
}
