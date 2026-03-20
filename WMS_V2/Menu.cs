// =========================
// Console Menu
// =========================
class ConsoleMenu
{
    private SurgeManager manager;
    private Caster caster;

    public ConsoleMenu(SurgeManager manager, Caster caster)
    {
        this.manager = manager;
        this.caster = caster;
    }

    public void ShowMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Cast Spell");
            Console.WriteLine("2. Manual Surge");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    HandleCastSpell();
                    break;
                case "2":
                    HandleManualSurge();
                    break;
                case "3":
                    running = false;
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