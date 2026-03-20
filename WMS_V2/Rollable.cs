// =========================
// Rollable Surge
// =========================
class Rollable : Surge
{
    private int diceType;
    private int diceNum;
    private int bonus;
    private DiceRoller dice;

    public Rollable(int id, char type, int power, string description,
                            int diceNum, int diceType, int bonus)
        : base(id, type, power, description)
    {
        this.diceNum = diceNum;
        this.diceType = diceType;
        this.bonus = bonus;
        this.dice = new DiceRoller();
    }

    public int Roll()
    {
        return dice.Roll(diceNum, diceType) + bonus;
    }

    public override void Display()
    {
        int result = Roll();
        Console.WriteLine($"{description} (Rolled: {result})");
    }
}
