namespace Car;

public class Car
{
    public Wheels wheelsInfo;
    public Wheel[] Wheels;
    public Engine _Engine;
    public Suspension _Suspension;
    public Cabin _Cabin;
    public object[] details;
    public IEnumerator<object> GetEnumerator() => new CarEnumerator(details);
    public Car(int wheelsCount)
    {
        Wheels = new Wheel[wheelsCount];
        for (int i = 0; i < wheelsCount; i++)
        {
            Wheels[i] = new Wheel();
        }
        _Engine = new Engine();
        _Suspension = new Suspension();
        _Cabin = new Cabin();
        wheelsInfo = new Wheels(wheelsCount);
        details = new object[] { _Engine, _Suspension, _Cabin, wheelsInfo, Wheels };
    }
}