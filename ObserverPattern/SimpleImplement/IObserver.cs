namespace ObserverPattern.SimpleImplement;

/// <summary>
/// 观察者接口
/// </summary>
public interface IObserver
{
    void Update(decimal price);
}
