// =========================
// Surge Manager
// =========================
using System.Reflection.Metadata;

class SurgeManager
{
    private SurgeTable _surges;
    private List<Surge> _history;
    private List<char> _types;
    private List<int> _powers;
    private Constant _default; 

    public SurgeManager(SurgeTable table)
    {
        _surges = table;
        _history = new List<Surge>();
        _types = new List<char> {'B', 'V', 'H'};
        _powers = new List<int> {1,2,3,4};
        _default = new Constant(0, 'B', 1, "No surges were found. Please try again.");
    }

    public Surge GetSurge()
    {
        Surge surge = _surges.GetSurge();
        _history.Add(surge);
        return surge;
    }

    public Surge GetFilteredSurge(List<char> types, List<int> powers)
    {
        List<Surge> filtered = _surges.FilterSurge(types, powers);

        if (filtered.Count == 0)
            return _default;

        Random rand = new Random();
        Surge surge = filtered[rand.Next(filtered.Count)];

        _history.Add(surge);
        return surge;
    }
}

