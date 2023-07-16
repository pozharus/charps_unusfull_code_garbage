namespace Car;

public class Wheels: BaseDetail
{
    public int wheelsCount;
    public Wheels(int wheelsCount) => this.wheelsCount = wheelsCount;
    public override string ToString()
    {
        return $@"This is wheels by count {wheelsCount}";
    }
}