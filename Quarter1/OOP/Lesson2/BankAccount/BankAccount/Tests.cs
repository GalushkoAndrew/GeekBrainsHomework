using System;

namespace GeekBrains.Learn.BankAccount
{
    public class Tests
    {
        public void Start()
        {
            Account_v1 account_V1 = new();
            Console.WriteLine(account_V1.GetType());
            account_V1.SetAccountType(AccountTypes.Currency);
            account_V1.SetNumber(321);
            account_V1.SetBalance(100500);
            Console.WriteLine(account_V1.ToString());
            Console.WriteLine("--------------------");

            Account_v2 account_V2 = new();
            Console.WriteLine(account_V2.GetType());
            account_V2.SetAccountType(AccountTypes.Currency);
            account_V2.GenerateNewNumber();
            account_V2.SetBalance(100502);
            Console.WriteLine(account_V2.ToString());
            Console.WriteLine("--------------------");

            Account_v3 account_V3 = new(12.5F, AccountTypes.Cumulative);
            Console.WriteLine(account_V3.GetType());
            Console.WriteLine(account_V3.ToString());
            Console.WriteLine("----");

            Account_v3 account_V3_2 = new(500.1F, AccountTypes.Savings);
            Console.WriteLine(account_V3_2.ToString());
            account_V3_2.PutMoney(100500);
            Console.WriteLine(account_V3_2.ToString());
            account_V3_2.GetMoney(15.18F);
            Console.WriteLine(account_V3_2.ToString());
            Console.WriteLine(account_V3_2.GetMoney(500000) ? "Снятие со счета успешно" : "Снятие со счета не успешно");
            Console.WriteLine(account_V3_2.ToString());
            account_V3_2.Balance = 882255;
            Console.WriteLine(account_V3_2.ToString());
            account_V3_2.AccountType = AccountTypes.Currency;
            Console.WriteLine(account_V3_2.ToString());
            Console.WriteLine("----");
        }
    }
}
