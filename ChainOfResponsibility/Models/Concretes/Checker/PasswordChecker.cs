using ChainOfResponsibility.Models.Abstracts;

namespace ChainOfResponsibility.Models.Concretes.Checker;

public class PasswordChecker : BaseChecker
{
    public override void Check(object? request)
    {
        if (request is Person person)
        {
            if (!string.IsNullOrEmpty(person.Password) && person.Password.Length > 6)
            {
                Console.WriteLine("Password is valid");
                Next?.Check(request);
            }
            else
            {
                Console.WriteLine("Password is invalid...");
            }
        }
        
    }
}
