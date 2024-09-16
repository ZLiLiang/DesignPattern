namespace CommandPattern;

/// <summary>
/// 强制命令
/// </summary>
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
