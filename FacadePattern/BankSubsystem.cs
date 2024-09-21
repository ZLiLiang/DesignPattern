namespace FacadePattern;

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
