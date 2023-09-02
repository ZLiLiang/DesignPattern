namespace DesignPattern.Builder
{
    public class BuilderExample
    {
        public static void Example()
        {
            Director director = new Director();
            CarBuilder builder = new FerrariBuilder();
            Car ferrari = director.Construct(builder);

            Console.WriteLine($"Engine: {ferrari.Engine}, Wheels: {ferrari.Wheels}, Doors: {ferrari.Doors}");
            Console.ReadLine();
        }
    }
}
