namespace ChainofResponsibility;

/// <summary>
/// 单据
/// </summary>
public abstract class Bill
{
    public string BillName { get; set; }

    public string BilNo { get; set; }

    public BillStatus Status { get; set; }

    public string MaterialName { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public decimal Amount
    {
        get
        {
            return Qty * Price;
        }
    }

    /// <summary>
    /// 做单员
    /// </summary>
    public BillHandler BillMaker { get; set; }
}
