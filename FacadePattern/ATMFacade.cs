using System.Security.Principal;

namespace FacadePattern;

/// <summary>
/// ATM机专属门面
/// </summary>
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
