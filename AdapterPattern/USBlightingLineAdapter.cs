namespace AdapterPattern;

/// <summary>
/// 苹果充电线适配器 <br/>
/// 类适配器模式
/// </summary>
public class USBlightingLineAdapter : USBLine, IChargingLine
{
    public void Charging()
    {
        Console.WriteLine("对USB-Lighting端口的数据线进行适配！");
        base.Charge();
    }
}
