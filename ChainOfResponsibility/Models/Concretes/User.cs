using ChainOfResponsibility.Models.Abstracts;

namespace ChainOfResponsibility.Models.Concretes;

public class User : Person
{
    public User(string username, string email, string password) : base(username, email, password)
    {
    }
}
