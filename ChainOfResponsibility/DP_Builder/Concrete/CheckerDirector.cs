using ChainOfResponsibility.DP_Builder.Abstract;
using ChainOfResponsibility.Models.Abstracts;
using ChainOfResponsibility.Models.Concretes.Checker;

namespace ChainOfResponsibility.DP_Builder.Concrete;

public class CheckerDirector 
{
    public ICheckerBuilder checkerBuilder { get; set; }


    public void MakeBuilder(Person person)
    {
        var emailChecker = new EmailChecker();
        var usernameChecker = new UsernameChecker();
        var passwordChecker = new PasswordChecker();

        usernameChecker.Next = passwordChecker;
        passwordChecker.Next = emailChecker;

        usernameChecker.Check(person);
    }

}
