using System;

namespace GeekBrains.Learn.BankAccount
{
    public class Tests
    {
        public void Start()
        {
            Account account = new(12.5F, AccountTypes.Cumulative);
            Console.WriteLine(account.GetType());
            Console.WriteLine(account.ToString());
            Console.WriteLine("----");

            Account account2 = new(500.1F, AccountTypes.Savings);
            Console.WriteLine(account2.ToString());
            account2.PutMoney(100500);
            Console.WriteLine(account2.ToString());
            account2.GetMoney(15.18F);
            Console.WriteLine(account2.ToString());
            Console.WriteLine(account2.GetMoney(500000) ? "Снятие со счета успешно" : "Снятие со счета не успешно");
            Console.WriteLine(account2.ToString());
            account2.AccountType = AccountTypes.Currency;
            Console.WriteLine(account2.ToString());
            Console.WriteLine("----");

            account2.GetMoneyFromAccount(account, 1F);
            Console.WriteLine(account.ToString());
            Console.WriteLine(account2.ToString());

            Account ac3 = new(5.1F, AccountTypes.Savings);
            Account ac4 = new(5.1F, AccountTypes.Savings);

            if (!(ac3 == ac4))
            {
                Console.WriteLine($"не соблюдается равенство {ac3} == {ac4}");
            }

            if (account != ac4)
            {
                Console.WriteLine($"{ac3} != {ac4}");
            }

        }
    }
}
