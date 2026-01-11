using ChainOfResponsibility.Models.Abstracts;

namespace ChainOfResponsibility.DP_Builder.Abstract;

public interface  ICheckerBuilder
{
    public BaseChecker EmailChecker { get; set; }
    public BaseChecker PasswordChecker { get; set; }
    public BaseChecker UserNameChecker { get; set; }
}
