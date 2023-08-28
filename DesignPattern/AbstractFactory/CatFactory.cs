namespace DesignPattern.AbstractFactory
{
    // 具体工厂：猫工厂
    public class CatFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Cat();
        }
    }
}
