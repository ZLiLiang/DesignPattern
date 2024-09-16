namespace CommandPattern;

/// <summary>
/// 谈判中心
/// </summary>
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
