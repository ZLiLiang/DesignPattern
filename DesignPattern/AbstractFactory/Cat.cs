namespace DesignPattern.AbstractFactory
{
    // 具体产品：猫
    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "Meow Meow";
        }
    }
}
