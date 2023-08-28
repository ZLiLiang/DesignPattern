namespace DesignPattern.AbstractFactory
{
    // 具体工厂：狗工厂
    public class DogFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }
}
