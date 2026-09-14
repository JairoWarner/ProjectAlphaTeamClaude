namespace ConsoleApp4;
public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public NPC? NPCHere;

    public Location(int id, string name, string description, Location north, Location east, Location south, Location west)
    {
        ID = id;
        Name = name;
        Description = description;
        LocationToNorth = north;
        LocationToEast = east;
        LocationToSouth = south;
        LocationToWest = west;
    }

    public void ShowMap()
    {
        Console.WriteLine($"                P              ");
        Console.WriteLine($"                |              ");
        Console.WriteLine($"                A              ");
        Console.WriteLine($"                |              ");
        Console.WriteLine($"    V  -  F  -  T  -  G  -  B  -  S    ");
        Console.WriteLine($"                |              ");
        Console.WriteLine($"                H              ");
    }
}
