namespace ObserverPattern.SimpleImplement;

/// <summary>
/// 被观察者接口 
/// <!--抽象目标或者主题-->
/// </summary>
public interface IObservable
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
