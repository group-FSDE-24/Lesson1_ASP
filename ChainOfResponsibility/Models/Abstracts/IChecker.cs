namespace ChainOfResponsibility.Models.Abstracts;

public interface IChecker
{
    public IChecker? Next{ get; set; }
    public void Check(object? request);
}
