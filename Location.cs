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
        Console.WriteLine($"                |     |         ");
        Console.WriteLine($"                H  -  S           ");
    }

    public void TownSquare(Player player)
    {
        if (Name == "Town square")
        {
            Item rustySword = World.ItemByID(World.WEAPON_ID_RUSTY_SWORD);
            Item club = World.ItemByID(World.WEAPON_ID_CLUB);
            Item healingPotion = World.ItemByID(World.ITEM_ID_HEALING_POTION);
            Item bread = World.ItemByID(World.ITEM_ID_JUST_BREAD);

            Inventory.AddItemsToInventory(rustySword.Name, rustySword.ID, rustySword.Description, rustySword.Equipped, rustySword.Type, rustySword.ForBattle, rustySword.Quantity, rustySword.IsStackable);
            Inventory.AddItemsToInventory(club.Name, club.ID, club.Description, club.Equipped, club.Type, club.ForBattle, club.Quantity, club.IsStackable);
            Inventory.AddItemsToInventory(healingPotion.Name, healingPotion.ID, healingPotion.Description, healingPotion.Equipped, healingPotion.Type, healingPotion.ForBattle, healingPotion.Quantity, healingPotion.IsStackable);
            Inventory.AddItemsToInventory(bread.Name, bread.ID, bread.Description, bread.Equipped, bread.Type, bread.ForBattle, bread.Quantity,  bread.IsStackable);

            Console.WriteLine($"On your way to Town square you found a {rustySword.Name}");

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}
