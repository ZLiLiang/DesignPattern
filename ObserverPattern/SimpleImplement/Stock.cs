using System;

namespace ObserverPattern.SimpleImplement;

/// <summary>
/// 实现被观察者
/// </summary>
public class Stock : IObservable
{
    private List<IObserver> observers = [];
    private decimal price;

    public decimal Price
    {
        get => price;
        set
        {
            price = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(price);
        }
    }
}
