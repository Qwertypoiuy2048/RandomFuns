// =========================
// Surge Table
// =========================
class SurgeTable
{
    private List<Surge> surges;
    private DiceRoller dice;

    public SurgeTable(List<Surge> surges)
    {
        this.surges = surges;
        this.dice = new DiceRoller();
    }

    public Surge GetSurge()
    {
        int index = dice.Select(surges.Count);
        // TODO: ask if good
        return surges[index];
    }

    public List<Surge> FilterSurge(List<char> types, List<int> powers)
    {
        List<Surge> result = new List<Surge>();

        foreach (var surge in surges)
        {
            if ((types.Count == 0 || types.Contains(surge.Type)) &&
                (powers.Count == 0 || powers.Contains(surge.Power)))
            {
                result.Add(surge);
            }
        }

        return result;
    }
}