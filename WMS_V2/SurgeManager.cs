// =========================
// Surge Manager
// =========================
class SurgeManager
{
    private SurgeTable surges;
    private List<Surge> history;
    private List<char> types;
    private List<int> powers;

    public SurgeManager(SurgeTable table)
    {
        surges = table;
        history = new List<Surge>();
        types = new List<char> {'B', 'V', 'H'};
        powers = new List<int> {1,2,3,4};
    }

    public Surge GetSurge()
    {
        Surge surge = surges.GetSurge();
        history.Add(surge);
        return surge;
    }

    public Surge GetFilteredSurge(List<char> types, List<int> powers)
    {
        List<Surge> filtered = surges.FilterSurge(types, powers);

        if (filtered.Count == 0)
            return null;

        Random rand = new Random();
        Surge surge = filtered[rand.Next(filtered.Count)];

        history.Add(surge);
        return surge;
    }
}

