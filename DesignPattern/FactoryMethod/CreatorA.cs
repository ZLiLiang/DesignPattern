namespace DesignPattern.FactoryMethod
{
    // 具体创建者A
    public class CreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }
}
