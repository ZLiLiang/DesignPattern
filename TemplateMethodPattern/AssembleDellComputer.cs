namespace TemplateMethodPattern;

/// <summary>
/// 组装HP电脑
/// </summary>
public class AssembleDellComputer : AssembleComputer
{
    public override void BuildMainFramePart()
    {
        Console.WriteLine("组装Dell电脑的主板");
    }

    public override void BuildScreenPart()
    {
        Console.WriteLine("组装Dell电脑的显示器");
    }

    public override void BuildInputPart()
    {
        Console.WriteLine("组装Dell电脑的键盘鼠标");
    }
}
