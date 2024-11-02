namespace MediatorPattern;

public interface IOrderMediator
{
    void ProcessOrder(Order order);
    void Notify(string message);
}
