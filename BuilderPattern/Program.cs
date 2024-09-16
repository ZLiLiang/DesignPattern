using BuilderPattern;

Director director = new();
HpBuilder hpBuilder = new();
DellBuilder dellBuilder = new();

//组装一批惠普电脑
Computer hp = director.Construct(hpBuilder);
hp.ShowSteps();

Console.WriteLine("-------------------");

//组装一批戴尔电脑
Computer dell = director.Construct(dellBuilder);
dell.ShowSteps();

Console.ReadLine();