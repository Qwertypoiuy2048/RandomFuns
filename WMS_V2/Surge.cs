public class Surge
{
    public char _severity;
    public char _type;
    public string _description;
    public int _line;

    public Surge(char severity, char type, string description, int line)
    {
        _severity = severity;
        _type = type;
        _description = description;
        _line = line;
    }
}