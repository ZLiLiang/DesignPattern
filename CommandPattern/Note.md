# 命令模式

将一个请求封装为一个对象，从而使你可以用不同的请求对客户进行参数化，对请求排队或记录请求日志，以及支持可撤销的操作。

命令角色（命令、和平命令和强制命令类）
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
    /// 抽象执行具体命令方法
    /// </summary>
    public abstract void Execute();
}
```

```
public class ForceCommand : Command
{
    private string _commandName = "强制命令";

    /// <summary>
    /// 重写默认构造函数，指定默认接收者
    /// 以降低高层模块对底层模块的依赖
    /// </summary>
    public ForceCommand() : base(new OperationCenter())
    {
        base.CommandName = _commandName;
    }

    /// <summary>
    /// 可通过构造函数重新指定接收者
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
    private string _commandName = "和平命令";

    /// <summary>
    /// 重写默认构造函数，指定默认接收者
    /// 以降低高层模块对底层模块的依赖
    /// </summary>
    public PeaceCommand() : base(new NegotiationCenter())
    {
        base.CommandName = _commandName;
    }

    /// <summary>
    /// 可通过构造函数重新指定接收者
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

接受者角色（接收者、操作中心和协商中心类）
```
public abstract class Receiver
{
    protected string ReceiverName { get; set; }

    /// <summary>
    /// 计划
    /// </summary>
    public abstract void Plan();

    /// <summary>
    /// 执行
    /// </summary>
    public abstract void Action();
}
```

```
public class OperationCenter : Receiver
{
    public OperationCenter()
    {
        this.ReceiverName = "操作中心";
    }

    public override void Plan()
    {
        Console.WriteLine($"{this.ReceiverName}：制定操作计划");
    }

    public override void Action()
    {
        Console.WriteLine($"{this.ReceiverName}：执行操作计划");
    }
}
```

```
public class NegotiationCenter : Receiver
{
    public NegotiationCenter()
    {
        this.ReceiverName = "谈判中心";
    }

    public override void Plan()
    {
        Console.WriteLine($"{this.ReceiverName}：制定谈判计划");
    }

    public override void Action()
    {
        Console.WriteLine($"{this.ReceiverName}：执行谈判计划");
    }
}
```

调用者角色（调用类）
```
public class Invoker
{
    public string InovkerName { get; set; }

    /// <summary>
    /// 申明调用的命令，并用构造函数注入
    /// </summary>
    private readonly Command _command;

    public Invoker(Command command)
    {
        _command = command;
    }

    /// <summary>
    /// 调用以执行具体命令
    /// </summary>
    public void Invoke()
    {
        Console.WriteLine($"『{this.InovkerName}』下达命令：{this._command.CommandName}");
        this._command.Execute();
    }
}
```