namespace DesignPattern.AbstractFactory
{
    // 具体产品：狗
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "Bark Bark";
        }
    }
}
