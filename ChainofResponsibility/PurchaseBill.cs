namespace ChainofResponsibility;

/// <summary>
/// 采购单据
/// </summary>
public class PurchaseBill : Bill
{
    public PurchaseBill()
    {
        base.Status = BillStatus.Open;
        base.BillName = "采购申请单";
    }
}
