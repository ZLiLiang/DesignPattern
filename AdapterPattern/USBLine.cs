namespace AdapterPattern;

/// <summary>
/// 原装数据线 <br/>
/// 未定义充电标准的充电方法
/// </summary>
public class USBLine
{
    public void Charge()
    {
        Console.WriteLine("为设备充电！");
    }
}
