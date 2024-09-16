using AdapterPattern;

//在未定义充电标准之前，各个厂家充电线的实现各不相同，但都可以为自家品牌设备充电
USBLine usbLine = new USBLine();
usbLine.Charge();

Console.WriteLine("-------------------");

//现在手里有一个未实现充电标准的充电线，通过适配器，为小米设备充电
Console.WriteLine("对象适配器模式：");
IChargingLine typeCLineAdapter = new USBTypecLineAdapter(usbLine);
typeCLineAdapter.Charging();

Console.WriteLine("-------------------");

//现在手里有一个未实现充电标准的充电线，通过适配器，为苹果设备充电
Console.WriteLine("类适配器模式：");
IChargingLine lightingLineAdapter = new USBlightingLineAdapter();
lightingLineAdapter.Charging();

Console.ReadLine();
