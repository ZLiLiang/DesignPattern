namespace DesignPattern.Builder
{
    // 指挥者
    public class Director
    {
        public Car Construct(CarBuilder carBuilder)
        {
            carBuilder.CreateNewCar();
            carBuilder.SetEngine();
            carBuilder.SetWheels();
            carBuilder.SetDoors();

            return carBuilder.GetCar();
        }
    }
}
