namespace TemplateMethodPattern;

/// <summary>
/// 组装HP电脑
/// </summary>
public class AssembleHpComputer : AssembleComputer
{
    public override void BuildMainFramePart()
    {
        Console.WriteLine("组装HP电脑的主板");
    }

    public override void BuildScreenPart()
    {
        Console.WriteLine("组装HP电脑的显示器");
    }

    public override void BuildInputPart()
    {
        Console.WriteLine("组装HP电脑的键盘鼠标");
    }
}
