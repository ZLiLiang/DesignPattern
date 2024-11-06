namespace VisitorPattern;

public interface IVisitor
{
    public abstract void Visit(SaleOrder saleOrder);
    public abstract void Visit(ReturnOrder returnOrder);
}
