namespace CustomerExample;

public class Account
{
    private readonly ReaderWriterLockSlim _readerWriterLockSlim = new();
    private decimal _balance;

    public Account(Customer customer, string accountNumber, decimal initialMoney)
    {
        if (initialMoney <= 0)
            throw new ArgumentOutOfRangeException(nameof(initialMoney));

        _balance = initialMoney;

        AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }

    public Customer Customer { get; }

    public string AccountNumber { get; }

    public decimal Balance
    {
        get
        {
            try
            {
                _readerWriterLockSlim.EnterReadLock();
                return _balance;
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }
        }
    }

    public decimal Withdraw(decimal value)
    {
        _readerWriterLockSlim.EnterWriteLock();

        if (value > _balance)
            throw new CustomException("Not enough money");

        _balance -= value;

        _readerWriterLockSlim.ExitWriteLock();
        
        return Balance;
    }

    public decimal Deposit(decimal value)
    {
        _readerWriterLockSlim.EnterWriteLock();

        if (value > decimal.MaxValue - _balance)
            throw new CustomException("We have nowhere to store so much money");

        _balance += value;

        _readerWriterLockSlim.ExitWriteLock();
        return Balance;
    }
}