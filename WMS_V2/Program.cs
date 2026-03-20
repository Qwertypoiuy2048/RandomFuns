class Program
{
    static void Main(string[] args)
    {
        Initialize Init = new Initialize();
        string path = Init.GetPath();

        CSVLoader loader = new CSVLoader();

        List<Surge> surges = loader.LoadCSV(path);

        SurgeTable table = new SurgeTable(surges);
        SurgeManager manager = new SurgeManager(table);
        Caster caster = new Caster();
        Menu menu = new Menu(manager, caster);

        menu.StartMenu();
    }
}


/*

Status: Runs with errors

Program - Functioning
Caster - Functioning
Constant -Functioning
CSVLoader -WIP
DiceRoller -Functioning
Initialize - Mock
Menu -WIP
Rollable - Functioning
Surge - Functioning
SurgeManager - WIP
SurgeTable - Mock

*/