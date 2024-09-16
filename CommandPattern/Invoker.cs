namespace CommandPattern;

/// <summary>
/// 调用者角色
/// </summary>
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
