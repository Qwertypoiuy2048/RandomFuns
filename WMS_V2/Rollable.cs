// =========================
// Rollable Surge
// =========================
class Rollable : Surge
{
    private int _diceType;
    private int _diceNum;
    private int _bonus;
    private DiceRoller _dice;

    public Rollable(int id, char type, int power, string description,
                            int diceNum, int diceType, int bonus)
        : base(id, type, power, description)
    {
        _diceNum = diceNum;
        _diceType = diceType;
        _bonus = bonus;
        _dice = new DiceRoller();
    }

    public int Roll()
    {
        return dice.Roll(diceNum, diceType) + bonus;
    }

    public override void Display()
    {
        Console.WriteLine($"\nLine num: {_id}\nType: {_type}\nSeverity: {_power}\n{_description}");
        
        int result = Roll();
        Console.WriteLine($"(Rolled: {result})\n\n");
    }
}
