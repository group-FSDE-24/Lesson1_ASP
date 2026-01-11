namespace ChainOfResponsibility.Models.Abstracts;

public abstract class Person
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    protected Person(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}
