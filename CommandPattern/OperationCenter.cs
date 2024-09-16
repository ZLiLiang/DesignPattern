namespace CommandPattern;

/// <summary>
/// 操作中心
/// </summary>
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
