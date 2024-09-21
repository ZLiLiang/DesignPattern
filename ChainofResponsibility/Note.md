# 责任链模式
使多个对象都有机会处理请求，从而避免了请求的发送者和接受者之间的耦合关系。将这些对象连成一条链，并沿着这条链传递该请求，直到有对象处理它为止。

状态（单据枚举类）
```
public enum BillStatus
{
    Open,
    Saved,
    Submitted,
    Audited
}
```

抽象实体（单据抽象实体类）
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
    /// 做单员
    /// </summary>
    public BillHandler BillMaker { get; set; }
}
```

实体（单据实体类）
```
public class PurchaseBill : Bill
{
    public PurchaseBill()
    {
        base.Status = BillStatus.Open;
        base.BillName = "采购申请单";
    }
}
```

抽象角色处理（单据抽象角色处理类）
```
public abstract class BillHandler
{
    /// <summary>
    /// 单据处理者姓名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 单据处理者具有的权限
    /// </summary>
    public List<string> Permissions { get; set; }

    /// <summary>
    /// 声明下一个处理者
    /// </summary>
    protected BillHandler Successor { get; set; }

    /// <summary>
    /// 对单据进行操作
    /// </summary>
    /// <param name="bill"></param>
    public abstract void DoBillOperation(Bill bill);

    /// <summary>
    /// 检查权限
    /// </summary>
    /// <param name="permission"></param>
    /// <returns></returns>
    public bool CheckPermission(string permission)
    {
        return Permissions.Contains(permission);
    }

    /// <summary>
    /// 处理单据
    /// </summary>
    /// <param name="bill"></param>
    public void HandleBill(Bill bill)
    {
        //单据处理从保存开始
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

角色处理（采购员、经理和总裁处理类）
```
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
```

```
public class Manager : BillHandler
{
    private List<string> permissions = ["SAVE", "SUBMIT", "AUDIT"];

    public Manager(string userName)
    {
        base.UserName = userName;
        base.Permissions = permissions;
        base.Successor = new CEO("CEO--链总");
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
            if (bill.Amount <= 20000)
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
```

## 优点
**降低耦合度**：发送者和接收者之间解耦。  
**简化对象**：对象不需要知道链的结构。  
**灵活性**：通过改变链的成员或顺序，动态地新增或删除责任。  
**易于扩展**：增加新的请求处理类很方便。

## 缺点
**请求未被处理**：不能保证请求一定会被链中的某个处理者接收。  
**性能影响**：可能影响系统性能，且调试困难，可能导致循环调用。  
**难以观察**：运行时特征不明显，可能妨碍除错。

## 使用场景
在处理请求时，如果有多个潜在的处理者，考虑使用责任链模式。  
确保链中的每个处理者都明确知道如何传递请求到链的下一个环节。

## 注意事项
在Web开发中，责任链模式有广泛应用，如过滤器链、拦截器等。