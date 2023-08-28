namespace DesignPattern.FactoryMethod
{
    public class FactoryMethodExample
    {
        public static void Example()
        {
            // 创建工厂对象
            Creator creatorA = new CreatorA();
            Creator creatorB = new CreatorB();

            // 通过工厂方法创建产品对象
            IProduct productA = creatorA.FactoryMethod();
            IProduct productB = creatorB.FactoryMethod();

            // 打印结果
            Console.WriteLine("ProductA says: " + productA.Operation());
            Console.WriteLine("ProductB says: " + productB.Operation());

            Console.ReadLine();
        }
    }
}
