namespace DesignPattern.Builder
{
    // 建造者抽象类
    public abstract class CarBuilder
    {
        protected Car car;

        public void CreateNewCar()
        {
            car = new Car();
        }

        public Car GetCar()
        {
            return car;
        }

        public abstract void SetEngine();
        public abstract void SetWheels();
        public abstract void SetDoors();
    }
}
