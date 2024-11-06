namespace VisitorPattern;

/// <summary>
/// 销售订单
/// </summary>
public class SaleOrder : Order
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
