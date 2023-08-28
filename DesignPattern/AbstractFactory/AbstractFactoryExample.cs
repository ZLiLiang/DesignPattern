namespace DesignPattern.AbstractFactory
{
    public class AbstractFactoryExample
    {
        public static void Example()
        {
            // 创建工厂
            IAnimalFactory dogFactory = new DogFactory();
            IAnimalFactory catFactory = new CatFactory();

            // 使用工厂创建产品
            IAnimal dog = dogFactory.CreateAnimal();
            IAnimal cat = catFactory.CreateAnimal();

            // 打印结果
            Console.WriteLine("Dog says: " + dog.Speak());
            Console.WriteLine("Cat says: " + cat.Speak());

            Console.ReadLine();
        }
    }
}
