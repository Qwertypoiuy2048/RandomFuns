// =========================
// Console Menu
// =========================
class ConsoleMenu
{
    private SurgeManager manager;
    private Caster caster;

    public ConsoleMenu(SurgeManager manager, Caster caster)
    {
        manager = manager;
        caster = caster;
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
                    caster.Reset();
                    break;
                default:
                    Console.WriteLine("Please enter a number on the list.");
                    break;
            }
        }
    }

    public void HandleInput()
    {
        // Optional: separate input handling if needed
    }

    private void HandleCastSpell()
    {
        Console.Write("Enter spell level: ");
        int level = int.Parse(Console.ReadLine());

        bool triggered = caster.CastSpell(level);

        if (triggered)
        {
            Surge surge = manager.GetSurge();
            surge.Display();
            caster.Reset();
        }
    }

    private void HandleManualSurge()
    {
        // TODO: Ask for type/power filters
        Surge surge = manager.GetFilteredSurge(new List<char>(), new List<int>());
        surge.Display();
    }
}