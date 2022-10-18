using CustomerExample;


Int32.TryParse(" asdfsdf", out var o);

Console.WriteLine(o);

var customerAccount = new Account(
    new Customer("Vasya", "Leonov", "kruzzze@mail.ru"),
    "123456789",
    1000);

var tasks = new List<Task>();
for (int i = 0; i < 10; i++)
{
    tasks.Add(Task.Run(() => customerAccount.Withdraw(10)));
    tasks.Add(Task.Run(() => customerAccount.Deposit(15)));
}

await Task.WhenAll(tasks);

Console.WriteLine(customerAccount.Balance);

Console.ReadKey();