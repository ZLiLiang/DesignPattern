namespace ChainofResponsibility;

public class CEO : BillHandler
{
    private List<string> permissions = ["SAVE", "SUBMIT", "AUDIT"];

    public CEO(string userName)
    {
        base.UserName = userName;
        base.Permissions = permissions;
    }

    public override void DoBillOperation(Bill bill)
    {
        if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
        {
            bill.Status = BillStatus.Saved;
            Console.WriteLine($"{this.UserName}：{bill.BilNo}已经保存！");
        }

        if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
        {
            bill.Status = BillStatus.Submitted;
            Console.WriteLine($"{this.UserName}：{bill.BilNo}已经提交！");
        }

        if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
        {
            Console.WriteLine($"{this.UserName}：{bill.BilNo}已经审核！");
        }
    }
}
