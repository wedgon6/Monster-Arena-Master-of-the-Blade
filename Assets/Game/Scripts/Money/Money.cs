public abstract class Money
{
    private int _value;

    public Money(int value)
    {
        _value = value;
    }

    public int Value => _value;

    public void ÑhangeValue(int amount)
    {
        _value += amount;
    }

    public bool CanSpend(int amount)
    {
        if (_value < amount)
            return false;
        else
            return true;
    }
}