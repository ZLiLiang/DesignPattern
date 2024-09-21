# ����ģʽ

��Ҳ��Ϊ���ģʽ��Ҫ��һ����ϵͳ���ⲿ�����ڲ���ͨ�ű���ͨ��һ��ͳһ�Ķ�����С�����ģʽ�ṩһ���߲�εĽӿڣ�ʹ����ϵͳ������ʹ�á�

��ϵͳ��ɫ���˻���ϵͳ�ࡢ������ϵͳ�ӿ��Լ�ʵ���ࣩ
```
public static class AccountSubsystem
{
    private static readonly List<BankAccount> Accounts = new List<BankAccount>
        {
            new BankAccount("123455", "555555", "ʥ��", "138****9309", 1000000),
            new BankAccount("123454", "444444", "��Ʒ��", "157****9309", 2000000),
            new BankAccount("123453", "333333", "��Ӫ��", "154****9309", 3000000),
            new BankAccount("123452", "222222", "����Գ", "187****9309", 4000000),
            new BankAccount("123451", "111111", "���ʨ", "189****9309", 5000000)
        };

    public static BankAccount Login(string bankNo, string password)
    {
        var bankAccount = Accounts.FirstOrDefault(a => a.BankNo == bankNo);
        if (bankAccount == null)
            throw new Exception("��Ч���ţ�����");

        if (bankAccount.Password != password)
            throw new Exception("������󣡣���");

        return bankAccount;
    }

    public static BankAccount GetAccount(string bankNo)
    {
        var bankAccount = Accounts.FirstOrDefault(a => a.BankNo == bankNo);
        if (bankAccount == null)
            throw new Exception("��Ч���ţ�����");


        return bankAccount;
    }

    public static void Display(BankAccount account)
    {
        Console.WriteLine($"���ţ�{account.BankNo}���ֿ���������{account.Name}���ֻ��ţ�{account.Phone}����{account.TotalMoney}");
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
    /// ��ѯ���
    /// </summary>
    /// <param name="account">�����˻�</param>
    /// <returns></returns>
    int CheckBalance(BankAccount account);

    /// <summary>
    /// ȡ��
    /// </summary>
    /// <param name="account">�����˻�</param>
    /// <param name="money">ȡ����Ǯ</param>
    /// <returns></returns>
    bool WithdrewMoney(BankAccount account, int money);

    /// <summary>
    /// ���
    /// </summary>
    /// <param name="account">�����˻�</param>
    /// <param name="money">�����Ǯ</param>
    /// <returns></returns>
    bool DepositMoney(BankAccount account, int money);

    /// <summary>
    /// ת��
    /// </summary>
    /// <param name="account">ת���˻�</param>
    /// <param name="targetNo">Ŀ���˻�</param>
    /// <param name="money">ת����Ǯ</param>
    /// <returns></returns>
    bool TransferMoney(BankAccount account, string targetNo, int money);

    /// <summary>
    /// ��ֵ����
    /// </summary>
    /// <param name="account">�����˻�</param>
    /// <param name="phoneNumber">�ֻ���</param>
    /// <param name="money">��ֵ����</param>
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
            throw new Exception("���㣡");
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
            throw new Exception("Ŀ���˻������ڣ�");

        if (account.TotalMoney < money)
            throw new Exception("���㣡");

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

�����ɫ��ATM�����ࣩ
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
    /// ȡ��
    /// </summary>
    /// <param name="money"></param>
    public void WithdrewCash(int money)
    {
        if (_bankSubsystem.WithdrewMoney(_bankAccount, money))
        {
            Console.WriteLine("ȡ��ɹ���");
            AccountSubsystem.Display(_bankAccount);
        }
    }

    /// <summary>
    /// ���
    /// </summary>
    /// <param name="money"></param>
    public void DepositCash(int money)
    {
        if (_bankSubsystem.DepositMoney(_bankAccount, money))
        {
            Console.WriteLine("���ɹ���");
            AccountSubsystem.Display(_bankAccount);
        }
    }

    /// <summary>
    /// �����
    /// </summary>
    public void QueryBalance()
    {
        if (_bankSubsystem.CheckBalance(_bankAccount) > 0)
            AccountSubsystem.Display(_bankAccount);
    }

    /// <summary>
    /// ת��
    /// </summary>
    /// <param name="targetNo"></param>
    /// <param name="money"></param>
    public void TransferMoney(string targetNo, int money)
    {
        if (_bankSubsystem.TransferMoney(_bankAccount, targetNo, money))
        {
            Console.WriteLine("ת�˳ɹ���");
            AccountSubsystem.Display(_bankAccount);
        }
    }
}
```

�ͻ��ˣ�ATM�ࣩ
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
                    Console.WriteLine("���������п��ţ�");
                    var bkNo = Console.ReadLine();
                    Console.WriteLine("���������룺");
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
        Console.WriteLine("��ӭ�㣡��ѡ�������Ŀ��");
        Console.WriteLine("1��ȡ��");
        Console.WriteLine("2�����");
        Console.WriteLine("3��ת��");
        Console.WriteLine("4����ѯ���");
        Console.WriteLine("5������");
        Console.WriteLine("==========================================");

        var pressKey = Console.ReadKey();

        switch (pressKey.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine();
                Console.WriteLine("������ȡ���");
                var money = Convert.ToInt32(Console.ReadLine());
                facade.WithdrewCash(money);
                break;
            case ConsoleKey.D2:
                Console.WriteLine();
                Console.WriteLine("���������");
                var depositNum = Convert.ToInt32(Console.ReadLine());
                facade.DepositCash(depositNum);
                break;
            case ConsoleKey.D3:
                Console.WriteLine();
                Console.WriteLine("������Ŀ���˺ţ�");
                var targetNo = Console.ReadLine();
                Console.WriteLine("������ת�˽�");
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
                Console.WriteLine("������������������");
                Console.ResetColor();
                break;
        }
    }

}
```

## �ŵ�
**��������**���ͻ�������ϵͳ֮����������١�  
**��������**����ϵͳ���ڲ��仯����Ӱ��ͻ��ˡ�  
**��ǿ��ȫ��**����������ϵͳ���ڲ�ʵ�֣�ֻ��¶��Ҫ�Ĳ�����

## ȱ��
**Υ������ԭ��**������ϵͳ���޸Ŀ�����Ҫ������������Ӧ���޸ġ�

## ע������
���ģʽ�����ڲ�λ��ṹ������Ϊÿһ���ṩһ����������ڡ�  
�������ʹ�����ģʽ���������ع����ϸ�ڣ�����ά�����ѡ�