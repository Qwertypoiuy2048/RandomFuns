public class ActiveSurge : Surge
{
    public int _roundsRemaining;

    public ActiveSurge(char severity, string type, string description, int line, int roundsRemaining) : base(severity, type, description, line)
    {
        _roundsRemaining = roundsRemaining;
    }
    public ActiveSurge(Surge surge, int roundsRemaining) : base(surge._severity, surge._type, surge._description, surge._line)
    {
        _roundsRemaining = roundsRemaining;
    }

    public void DecrementRound()
    {
        _roundsRemaining--;
        if (_roundsRemaining <= 0)
        {
            Console.WriteLine($"Surge expired: {_description}");
        }
    }
}
