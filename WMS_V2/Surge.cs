// =========================
// Abstract Surge
// =========================
abstract class Surge
{
    protected int _id;
    protected char _type;
    protected int _power;
    protected string _description;

    public char Type => type;
    public int Power => power;

    public Surge(int id, char type, int power, string description)
    {
        _id = id;
        _type = type;
        _power = power;
        _description = description;
    }

    public abstract void Display();
}