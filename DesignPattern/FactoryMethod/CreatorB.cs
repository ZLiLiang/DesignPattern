namespace DesignPattern.FactoryMethod
{
    // 具体创建者B
    public class CreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }
}
