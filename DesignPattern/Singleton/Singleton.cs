namespace DesignPattern.Singleton
{
    public class Singleton
    {
        //创建一个只读的静态Singleton实例
        private static readonly Singleton instance = new Singleton();

        // 记录Singleton的创建次数
        private static int instanceCounter = 0;

        // 单例实例的公共访问点
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        // 私有构造函数
        private Singleton()
        {
            instanceCounter++;
            Console.WriteLine("Instances Created " + instanceCounter);
        }

        // 在此处添加其他的Singleton类方法
        public void LogMessage(string message)
        {
            Console.WriteLine("Message: " + message);
        }
    }
}
