using System.Collections;

namespace Car;

public class CarEnumerator: IEnumerator<object>
{
    public object[] details;
    public int position = -1;
    public CarEnumerator(object[] details) => this.details = details;
    
    public object Current
    {
        get
        {
            if (position == -1 || position >= details.Length)
                throw new ArgumentException();
            return details[position];
        }
    }
    public bool MoveNext()
    {
        if (position < details.Length - 1)
        {
            position++;
            return true;
        } 
        return false;
    }
    public void Reset() => position = -1;
    public void Dispose() { }
}