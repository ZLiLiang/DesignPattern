namespace ChainofResponsibility;

public class Purchaser : BillHandler
{
    private List<string> permissions = ["SAVE"];

    public Purchaser(string userName)
    {
        base.UserName = userName;
        base.Permissions = permissions;
        base.Successor = new Manager("经理--任经理");
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
            if (bill.Amount <= 5000)
            {
                Console.WriteLine($"{this.UserName}：{bill.BilNo}已经审核！");
            }
            else
            {
                this.Successor.DoBillOperation(bill);
            }
        }
        else
        {
            this.Successor.DoBillOperation(bill);
        }
    }
}
