namespace CommandPattern;

/// <summary>
/// 和平命令
/// </summary>
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
