namespace CommandPattern;

/// <summary>
/// 接收者角色
/// </summary>
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
