namespace DesignPattern.Builder
{
    // 具体建造者
    public class FerrariBuilder : CarBuilder
    {
        public override void SetEngine()
        {
            car.Engine = "V8";
        }

        public override void SetWheels()
        {
            car.Wheels = "18 inch";
        }

        public override void SetDoors()
        {
            car.Doors = "2";
        }
    }
}
