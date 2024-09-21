# 门面模式

（也称为外观模式）要求一个子系统的外部与其内部的通信必须通过一个统一的对象进行。门面模式提供一个高层次的接口，使得子系统更易于使用。

子系统角色（账户子系统类、银行子系统接口以及实现类）
```
public static class AccountSubsystem
{
    private static readonly List<BankAccount> Accounts = new List<BankAccount>
        {
            new BankAccount("123455", "555555", "圣杰", "138****9309", 1000000),
            new BankAccount("123454", "444444", "产品汪", "157****9309", 2000000),
            new BankAccount("123453", "333333", "运营喵", "154****9309", 3000000),
            new BankAccount("123452", "222222", "程序猿", "187****9309", 4000000),
            new BankAccount("123451", "111111", "设计狮", "189****9309", 5000000)
        };

    public static BankAccount Login(string bankNo, string password)
    {
        var bankAccount = Accounts.FirstOrDefault(a => a.BankNo == bankNo);
        if (bankAccount == null)
            throw new Exception("无效卡号！！！");

        if (bankAccount.Password != password)
            throw new Exception("密码错误！！！");

        return bankAccount;
    }

    public static BankAccount GetAccount(string bankNo)
    {
        var bankAccount = Accounts.FirstOrDefault(a => a.BankNo == bankNo);
        if (bankAccount == null)
            throw new Exception("无效卡号！！！");


        return bankAccount;
    }

    public static void Display(BankAccount account)
    {
        Console.WriteLine($"卡号：{account.BankNo}，持卡人姓名：{account.Name}，手机号：{account.Phone}，余额：{account.TotalMoney}");
    }


    public static bool ChangePassword()
    {
        throw new NotImplementedException();
    }
}
```

```
public interface IBankSubsystem
{
    /// <summary>
    /// 查询余额
    /// </summary>
    /// <param name="account">银行账户</param>
    /// <returns></returns>
    int CheckBalance(BankAccount account);

    /// <summary>
    /// 取款
    /// </summary>
    /// <param name="account">银行账户</param>
    /// <param name="money">取多少钱</param>
    /// <returns></returns>
    bool WithdrewMoney(BankAccount account, int money);

    /// <summary>
    /// 存款
    /// </summary>
    /// <param name="account">银行账户</param>
    /// <param name="money">存多少钱</param>
    /// <returns></returns>
    bool DepositMoney(BankAccount account, int money);

    /// <summary>
    /// 转账
    /// </summary>
    /// <param name="account">转出账户</param>
    /// <param name="targetNo">目标账户</param>
    /// <param name="money">转多少钱</param>
    /// <returns></returns>
    bool TransferMoney(BankAccount account, string targetNo, int money);

    /// <summary>
    /// 充值话费
    /// </summary>
    /// <param name="account">银行账户</param>
    /// <param name="phoneNumber">手机号</param>
    /// <param name="money">充值多少</param>
    /// <returns></returns>
    bool RechargeMobilePhone(BankAccount account, string phoneNumber, int money);
}
```

```
public class BankSubsystem : IBankSubsystem
{
    public int CheckBalance(BankAccount account)
    {
        return account.TotalMoney;
    }

    public bool WithdrewMoney(BankAccount account, int money)
    {
        if (account.TotalMoney < money)
        {
            throw new Exception("余额不足！");
        }

        account.TotalMoney -= money;

        return true;
    }

    public bool DepositMoney(BankAccount account, int money)
    {
        account.TotalMoney += money;

        return true;
    }

    public bool TransferMoney(BankAccount account, string targetNo, int money)
    {
        var targetAccount = AccountSubsystem.GetAccount(targetNo);

        if (targetAccount == null)
            throw new Exception("目标账户不存在！");

        if (account.TotalMoney < money)
            throw new Exception("余额不足！");

        account.TotalMoney -= money;
        targetAccount.TotalMoney += money;

        return true;
    }

    public bool RechargeMobilePhone(BankAccount account, string phoneNumber, int money)
    {
        throw new NotImplementedException();
    }
}
```

门面角色（ATM门面类）
```
public class ATMFacade
{
    private readonly IBankSubsystem _bankSubsystem;
    private BankAccount _bankAccount;

    public ATMFacade()
    {
        _bankSubsystem = new BankSubsystem();
    }

    public void Login(string no, string pwd)
    {
        _bankAccount = AccountSubsystem.Login(no, pwd);
    }

    public bool IsLogin()
    {
        return _bankAccount != null;
    }

    /// <summary>
    /// 取款
    /// </summary>
    /// <param name="money"></param>
    public void WithdrewCash(int money)
    {
        if (_bankSubsystem.WithdrewMoney(_bankAccount, money))
        {
            Console.WriteLine("取款成功！");
            AccountSubsystem.Display(_bankAccount);
        }
    }

    /// <summary>
    /// 存款
    /// </summary>
    /// <param name="money"></param>
    public void DepositCash(int money)
    {
        if (_bankSubsystem.DepositMoney(_bankAccount, money))
        {
            Console.WriteLine("存款成功！");
            AccountSubsystem.Display(_bankAccount);
        }
    }

    /// <summary>
    /// 查余额
    /// </summary>
    public void QueryBalance()
    {
        if (_bankSubsystem.CheckBalance(_bankAccount) > 0)
            AccountSubsystem.Display(_bankAccount);
    }

    /// <summary>
    /// 转账
    /// </summary>
    /// <param name="targetNo"></param>
    /// <param name="money"></param>
    public void TransferMoney(string targetNo, int money)
    {
        if (_bankSubsystem.TransferMoney(_bankAccount, targetNo, money))
        {
            Console.WriteLine("转账成功！");
            AccountSubsystem.Display(_bankAccount);
        }
    }
}
```

客户端（ATM类）
```
public class ATM
{
    public void DisplayUi()
    {
        var facade = new ATMFacade();

        while (true)
            try
            {
                if (!facade.IsLogin())
                {
                    Console.WriteLine("请输入银行卡号：");
                    var bkNo = Console.ReadLine();
                    Console.WriteLine("请输入密码：");
                    var pwd = Console.ReadLine();
                    facade.Login(bkNo, pwd);
                }
                else
                {
                    ShowBusiness(facade);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
    }


    private static void ShowBusiness(ATMFacade facade)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("欢迎你！请选择服务项目：");
        Console.WriteLine("1、取款");
        Console.WriteLine("2、存款");
        Console.WriteLine("3、转账");
        Console.WriteLine("4、查询余额");
        Console.WriteLine("5、清屏");
        Console.WriteLine("==========================================");

        var pressKey = Console.ReadKey();

        switch (pressKey.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine();
                Console.WriteLine("请输入取款金额：");
                var money = Convert.ToInt32(Console.ReadLine());
                facade.WithdrewCash(money);
                break;
            case ConsoleKey.D2:
                Console.WriteLine();
                Console.WriteLine("请输入存款金额：");
                var depositNum = Convert.ToInt32(Console.ReadLine());
                facade.DepositCash(depositNum);
                break;
            case ConsoleKey.D3:
                Console.WriteLine();
                Console.WriteLine("请输入目标账号：");
                var targetNo = Console.ReadLine();
                Console.WriteLine("请输入转账金额：");
                var transferNum = Convert.ToInt32(Console.ReadLine());
                facade.TransferMoney(targetNo, transferNum);
                break;
            case ConsoleKey.D4:
                Console.WriteLine();
                facade.QueryBalance();
                break;
            case ConsoleKey.D5:
                Console.Clear();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("输入有误，请重新输入");
                Console.ResetColor();
                break;
        }
    }

}
```

## 优点
**减少依赖**：客户端与子系统之间的依赖减少。  
**提高灵活性**：子系统的内部变化不会影响客户端。  
**增强安全性**：隐藏了子系统的内部实现，只暴露必要的操作。

## 缺点
**违反开闭原则**：对子系统的修改可能需要对外观类进行相应的修改。

## 注意事项
外观模式适用于层次化结构，可以为每一层提供一个清晰的入口。  
避免过度使用外观模式，以免隐藏过多的细节，导致维护困难。