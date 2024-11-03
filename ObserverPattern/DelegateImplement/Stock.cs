namespace ObserverPattern.DelegateImplement;

/// <summary>
/// 被观察者
/// </summary>
public class Stock
{
    // 定义委托类型，用于价格变化通知
    public delegate void PriceChangedHandler(decimal newPrice);

    // 定义事件，类型为 PriceChangedHandler
    public event PriceChangedHandler PriceChanged;

    private decimal price;
    public decimal Price
    {
        get { return price; }
        set
        {
            price = value;
            // 当价格变化时触发 PriceChanged 事件
            OnPriceChanged(price);
        }
    }

    // 触发 PriceChanged 事件的方法
    protected virtual void OnPriceChanged(decimal newPrice)
    {
        if (PriceChanged != null)
        {
            PriceChanged(newPrice);
        }
    }
}
