// =========================
// Constant Surge
// =========================

class Constant : Surge
{
    public Constant(int id, char type, int power, string description)
        : base(id, type, power, description) { }

    public override void Display()
    {
        Console.WriteLine(description);
    }
}

