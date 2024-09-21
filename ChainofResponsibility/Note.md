# ������ģʽ
ʹ��������л��ᴦ�����󣬴Ӷ�����������ķ����ߺͽ�����֮�����Ϲ�ϵ������Щ��������һ���������������������ݸ�����ֱ���ж�������Ϊֹ��

״̬������ö���ࣩ
```
public enum BillStatus
{
    Open,
    Saved,
    Submitted,
    Audited
}
```

����ʵ�壨���ݳ���ʵ���ࣩ
```
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
    /// ����Ա
    /// </summary>
    public BillHandler BillMaker { get; set; }
}
```

ʵ�壨����ʵ���ࣩ
```
public class PurchaseBill : Bill
{
    public PurchaseBill()
    {
        base.Status = BillStatus.Open;
        base.BillName = "�ɹ����뵥";
    }
}
```

�����ɫ�������ݳ����ɫ�����ࣩ
```
public abstract class BillHandler
{
    /// <summary>
    /// ���ݴ���������
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// ���ݴ����߾��е�Ȩ��
    /// </summary>
    public List<string> Permissions { get; set; }

    /// <summary>
    /// ������һ��������
    /// </summary>
    protected BillHandler Successor { get; set; }

    /// <summary>
    /// �Ե��ݽ��в���
    /// </summary>
    /// <param name="bill"></param>
    public abstract void DoBillOperation(Bill bill);

    /// <summary>
    /// ���Ȩ��
    /// </summary>
    /// <param name="permission"></param>
    /// <returns></returns>
    public bool CheckPermission(string permission)
    {
        return Permissions.Contains(permission);
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="bill"></param>
    public void HandleBill(Bill bill)
    {
        //���ݴ���ӱ��濪ʼ
        if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
        {
            this.DoBillOperation(bill);
        }
        else
        {
            this.Successor.DoBillOperation(bill);
        }
    }
}
```

��ɫ�����ɹ�Ա��������ܲô����ࣩ
```
public class Purchaser : BillHandler
{
    private List<string> permissions = ["SAVE"];

    public Purchaser(string userName)
    {
        base.UserName = userName;
        base.Permissions = permissions;
        base.Successor = new Manager("����--�ξ���");
    }

    public override void DoBillOperation(Bill bill)
    {
        if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
        {
            bill.Status = BillStatus.Saved;
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ����棡");
        }

        if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
        {
            bill.Status = BillStatus.Submitted;
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ��ύ��");
        }

        if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
        {
            if (bill.Amount <= 5000)
            {
                Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ���ˣ�");
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
```

```
public class Manager : BillHandler
{
    private List<string> permissions = ["SAVE", "SUBMIT", "AUDIT"];

    public Manager(string userName)
    {
        base.UserName = userName;
        base.Permissions = permissions;
        base.Successor = new CEO("CEO--����");
    }

    public override void DoBillOperation(Bill bill)
    {
        if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
        {
            bill.Status = BillStatus.Saved;
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ����棡");
        }

        if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
        {
            bill.Status = BillStatus.Submitted;
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ��ύ��");
        }

        if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
        {
            if (bill.Amount <= 20000)
            {
                Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ���ˣ�");
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
```

```
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
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ����棡");
        }

        if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
        {
            bill.Status = BillStatus.Submitted;
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ��ύ��");
        }

        if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
        {
            Console.WriteLine($"{this.UserName}��{bill.BilNo}�Ѿ���ˣ�");
        }
    }
}
```

## �ŵ�
**������϶�**�������ߺͽ�����֮����  
**�򻯶���**��������Ҫ֪�����Ľṹ��  
**�����**��ͨ���ı����ĳ�Ա��˳�򣬶�̬��������ɾ�����Ρ�  
**������չ**�������µ���������ܷ��㡣

## ȱ��
**����δ������**�����ܱ�֤����һ���ᱻ���е�ĳ�������߽��ա�  
**����Ӱ��**������Ӱ��ϵͳ���ܣ��ҵ������ѣ����ܵ���ѭ�����á�  
**���Թ۲�**������ʱ���������ԣ����ܷ�������

## ʹ�ó���
�ڴ�������ʱ������ж��Ǳ�ڵĴ����ߣ�����ʹ��������ģʽ��  
ȷ�����е�ÿ�������߶���ȷ֪����δ�������������һ�����ڡ�

## ע������
��Web�����У�������ģʽ�й㷺Ӧ�ã�������������������ȡ�