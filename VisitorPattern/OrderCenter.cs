namespace VisitorPattern;

/// <summary>
/// 订单中心
/// </summary>
public class OrderCenter : List<Order>
{
    public void Accept(IVisitor visitor)
    {
        var iterator = this.GetEnumerator();

        while (iterator.MoveNext())
        {
            iterator.Current.Accept(visitor);
        }
    }

}
