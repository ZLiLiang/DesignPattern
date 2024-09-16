# ����ģʽ

��һ�������װΪһ�����󣬴Ӷ�ʹ������ò�ͬ������Կͻ����в��������������Ŷӻ��¼������־���Լ�֧�ֿɳ����Ĳ�����

�����ɫ�������ƽ�����ǿ�������ࣩ
```
public abstract class Command
{
    public string CommandName { get; set; }

    protected readonly Receiver receiver;

    protected Command(Receiver receiver)
    {
        this.receiver = receiver;
    }

    /// <summary>
    /// ����ִ�о��������
    /// </summary>
    public abstract void Execute();
}
```

```
public class ForceCommand : Command
{
    private string _commandName = "ǿ������";

    /// <summary>
    /// ��дĬ�Ϲ��캯����ָ��Ĭ�Ͻ�����
    /// �Խ��͸߲�ģ��Եײ�ģ�������
    /// </summary>
    public ForceCommand() : base(new OperationCenter())
    {
        base.CommandName = _commandName;
    }

    /// <summary>
    /// ��ͨ�����캯������ָ��������
    /// </summary>
    /// <param name="receiver"></param>
    public ForceCommand(Receiver receiver) : base(receiver)
    {
        base.CommandName = _commandName;
    }

    public override void Execute()
    {
        this.receiver.Plan();
        this.receiver.Action();
    }
}
```

```
public class PeaceCommand : Command
{
    private string _commandName = "��ƽ����";

    /// <summary>
    /// ��дĬ�Ϲ��캯����ָ��Ĭ�Ͻ�����
    /// �Խ��͸߲�ģ��Եײ�ģ�������
    /// </summary>
    public PeaceCommand() : base(new NegotiationCenter())
    {
        base.CommandName = _commandName;
    }

    /// <summary>
    /// ��ͨ�����캯������ָ��������
    /// </summary>
    /// <param name="receiver"></param>
    public PeaceCommand(Receiver receiver) : base(receiver)
    {
        base.CommandName = _commandName;
    }

    public override void Execute()
    {
        this.receiver.Plan();
        this.receiver.Action();
    }
}
```

�����߽�ɫ�������ߡ��������ĺ�Э�������ࣩ
```
public abstract class Receiver
{
    protected string ReceiverName { get; set; }

    /// <summary>
    /// �ƻ�
    /// </summary>
    public abstract void Plan();

    /// <summary>
    /// ִ��
    /// </summary>
    public abstract void Action();
}
```

```
public class OperationCenter : Receiver
{
    public OperationCenter()
    {
        this.ReceiverName = "��������";
    }

    public override void Plan()
    {
        Console.WriteLine($"{this.ReceiverName}���ƶ������ƻ�");
    }

    public override void Action()
    {
        Console.WriteLine($"{this.ReceiverName}��ִ�в����ƻ�");
    }
}
```

```
public class NegotiationCenter : Receiver
{
    public NegotiationCenter()
    {
        this.ReceiverName = "̸������";
    }

    public override void Plan()
    {
        Console.WriteLine($"{this.ReceiverName}���ƶ�̸�мƻ�");
    }

    public override void Action()
    {
        Console.WriteLine($"{this.ReceiverName}��ִ��̸�мƻ�");
    }
}
```

�����߽�ɫ�������ࣩ
```
public class Invoker
{
    public string InovkerName { get; set; }

    /// <summary>
    /// �������õ�������ù��캯��ע��
    /// </summary>
    private readonly Command _command;

    public Invoker(Command command)
    {
        _command = command;
    }

    /// <summary>
    /// ������ִ�о�������
    /// </summary>
    public void Invoke()
    {
        Console.WriteLine($"��{this.InovkerName}���´����{this._command.CommandName}");
        this._command.Execute();
    }
}
```