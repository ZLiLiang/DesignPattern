using FactoryPattern;

TestSimpleFactory();
TestFactoryMethod();
TestReflectFactory();
TestAbstractFactory();
Console.ReadLine();

static void TestSimpleFactory()
{
    Console.WriteLine("简单工厂模式：");
    var productA = SimpleFactory.Create(ProductEnum.ConcreateProductA);
    productA.GetInfo();
}

static void TestFactoryMethod()
{
    Console.WriteLine("工厂方法模式：");
    IFactoryMethod factoryB = new ConcreateFactoryB();
    var productB = factoryB.Create();
    productB.GetInfo();
}

static void TestReflectFactory()
{
    Console.WriteLine("反射工厂模式：");
    var productB = ReflectFactory.Create("FactoryPattern.ConcreateCarB");
    productB.GetInfo();
}

static void TestAbstractFactory()
{
    Console.WriteLine("抽象工厂模式：");

    var bmwFactory = new BMWFactory();
    bmwFactory.CreateCar().GetInfo();
    bmwFactory.CreateBus().GetInfo();

    var bydFactory = new BYDFactory();
    bydFactory.CreateCar().GetInfo();
    bydFactory.CreateBus().GetInfo();
}