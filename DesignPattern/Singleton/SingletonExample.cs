namespace DesignPattern.Singleton
{
    public class SingletonExample
    {
        public static void Example()
        {
            Singleton fromEmployee = Singleton.Instance;
            fromEmployee.LogMessage("Message from Employee");

            Singleton fromBoss = Singleton.Instance;
            fromBoss.LogMessage("Message from Boss");
            Console.ReadLine();
        }
    }
}
