namespace VisitorPattern;

/// <summary>
/// 退货单
/// </summary>
public class ReturnOrder : Order
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
