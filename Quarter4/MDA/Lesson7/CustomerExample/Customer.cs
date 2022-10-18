namespace CustomerExample;

public class Customer
{
    public Customer(string name, string surname, Email email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Email = email;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Surname { get; }

    public Email Email { get; }
}