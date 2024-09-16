# 适配模式
将一个类的接口变换成客户端所期待的另一种接口，从而使原本因接口不匹配而无法在一起工作的两个类能够在一起工作。

待适配类（USB充电线类）
```
public class USBLine
{
    public void Charge()
    {
        Console.WriteLine("为设备充电！");
    }
}
```

接口标志适配标准（充电线接口）
```
public interface IChargingLine
{
    void Charging();
}
```

对象适配器模式（适配Type充电线类）
```
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
```

类适配器模式（适配lighting充电线类）
```
public class USBlightingLineAdapter : USBLine, IChargingLine
{
    public void Charging()
    {
        Console.WriteLine("对USB-Lighting端口的数据线进行适配！");
        base.Charge();
    }
}
```