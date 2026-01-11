namespace ChainOfResponsibility.Models.Abstracts;

// Imzalama 
public abstract class BaseChecker : IChecker
{
    public IChecker? Next { get ; set ; }

    public abstract void Check(object? request);

    // public abstract void Save(object requst); // Gelecekde olacaq

}
