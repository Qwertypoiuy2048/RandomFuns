public class ActiveSurges
{
    public List<ActiveSurge> _activeSurges;
    int _roundNumber;

    public ActiveSurges()
    {
        _activeSurges = new List<ActiveSurge>();
        _roundNumber = 0;
    }

    public void AddSurge(ActiveSurge surge)
    {
        _activeSurges.Add(surge);
    }

    public void ActivateSurge(Surge surge)
    {
        Console.WriteLine($"Activating surge: {surge._description} (Severity: {surge._severity}, Type: {surge._type})");
        Console.Write($"How many rounds? ");
        int rounds = int.Parse(Console.ReadLine());
        ActiveSurge activeSurge = new ActiveSurge(surge, rounds);
        // _activeSurges.Add(surge);
    }

    public void NextRound()
    {
        _roundNumber++;
        for (int i = _activeSurges.Count - 1; i >= 0; i--)
        {
            _activeSurges[i].DecrementRound();
            if (_activeSurges[i]._roundsRemaining <= 0)
            {
                _activeSurges.RemoveAt(i);
            }
        }
    }

    public void RemoveAll()
    {
        _activeSurges.Clear();
    }

    public void PrintActiveSurges()
    {
        Console.WriteLine($"Round {_roundNumber}: Active Surges:");
        foreach (ActiveSurge surge in _activeSurges)
        {
            Console.WriteLine($"- {surge._description} (Severity: {surge._severity}, Type: {surge._type}, Rounds Remaining: {surge._roundsRemaining})");
        }
    }
}
