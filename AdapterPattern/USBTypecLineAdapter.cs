namespace AdapterPattern;

/// <summary>
/// 小米充电线适配器 <br/>
/// 对象适配器模式
/// </summary>
public class USBTypecLineAdapter : IChargingLine
{
    private readonly USBLine _usbLine;

    public USBTypecLineAdapter(USBLine usbLine)
    {
        _usbLine = usbLine;
    }

    public void Charging()
    {
        Console.WriteLine("对USB-TypeC端口的数据线进行适配！");
        this._usbLine.Charge();
    }
}
