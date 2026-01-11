using ChainOfResponsibility.Models.Abstracts;

namespace ChainOfResponsibility.Models.Concretes.Checker;

public class EmailChecker : BaseChecker
{
    public override void Check(object? request)
    {
        if (request is Person person)
        {
            if (!string.IsNullOrEmpty(person.Email) && person.Email.Contains('@'))
            {
                Console.WriteLine("Email is valid");
                Next.Check(request);
            }
        }
        else
        {
            Console.WriteLine("Email is invalid...");
        }
    }
}
