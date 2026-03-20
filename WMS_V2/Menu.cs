// =========================
// Console Menu
// =========================
class Menu
{
    private SurgeManager _manager;
    private Caster _caster;

    public Menu(SurgeManager manager, Caster caster)
    {
        _manager = manager;
        _caster = caster;
    }

    public void StartMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Cast spell");
            Console.WriteLine("2. Manual surge");
            Console.WriteLine("3. Reset cast spells");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    HandleCastSpell();
                    break;
                case "2":
                    HandleManualSurge();
                    break;
                case "3":
                    _caster.Reset();
                    break;
                default:
                    Console.WriteLine("Please enter a number on the list.");
                    break;
            }
        }
    }

    private void HandleCastSpell()
    {
        Console.Write("Enter spell level: ");
        string input = Console.ReadLine();
        int level;
        if (int.TryParse(input, out int Input)) {level = Input;} else {level = 1;}

        bool triggered = _caster.CastSpell(level);

        if (triggered)
        {
            Surge surge = _manager.GetSurge();
            surge.Display();
            _caster.Reset();
        }
    }

    private void HandleManualSurge()
    {
        // TODO: Ask for type/power filters
        Console.Write("What Types? (B, V, H): ");
        List<char> types = Console.ReadLine().ToCharArray().ToList();

        Console.Write("What Powers? (1, 2, 3, 4): ");
        List<int> powers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        Surge surge = _manager.GetFilteredSurge(types, powers);
        surge.Display();
    }
}