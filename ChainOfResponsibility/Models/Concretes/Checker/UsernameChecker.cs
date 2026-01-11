using ChainOfResponsibility.Models.Abstracts;

namespace ChainOfResponsibility.Models.Concretes.Checker;

public class UsernameChecker : BaseChecker
{
    public override void Check(object? request)
    {
        if (request is Person person)
        {
            if (!string.IsNullOrEmpty(person.Username) && person.Username.Length > 6)
            {
                Console.WriteLine("Username is valid");
                Next?.Check(request);
            }
            else
            {
                Console.WriteLine("Username is invalid...");
            }
        }
    }
}
