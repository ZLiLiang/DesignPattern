namespace CommandPattern;

/// <summary>
/// 命令者角色
/// </summary>
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
