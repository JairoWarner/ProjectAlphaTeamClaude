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

    public Location(int id, string name, string description, Location north, Location east, Location south,
        Location west)
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
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        string reset = "\u001b[0m";
        string gray = "\u001b[37m";
        string cyan = "\u001b[96m";
        string green = "\u001b[92m";
        string yellow = "\u001b[93m";
        string darkGray = "\u001b[90m";

        string Point(string letter, int locationID)
        {
            if (ID == locationID)
            {
                return $"{yellow}[{letter}]{gray}";
            }

            return $"{green}[{letter}]{gray}";
        }

        string garden = Point("P", World.LOCATION_ID_ALCHEMISTS_GARDEN);
        string alchemist = Point("A", World.LOCATION_ID_ALCHEMIST_HUT);
        string field = Point("V", World.LOCATION_ID_FARM_FIELD);
        string farmhouse = Point("F", World.LOCATION_ID_FARMHOUSE);
        string town = Point("T", World.LOCATION_ID_TOWN_SQUARE);
        string guard = Point("G", World.LOCATION_ID_GUARD_POST);
        string bridge = Point("B", World.LOCATION_ID_BRIDGE);
        string forest = Point("S", World.LOCATION_ID_SPIDER_FIELD);
        string home = Point("H", World.LOCATION_ID_HOME);
        string shop = Point("S", World.LOCATION_ID_SHOP);
        
        Console.WriteLine($@"{cyan}
    ╔═══════════════════════════════════════════════════════════════════════════════════════════╗
    ║                                         WORLD MAP                                         ║
    ╚═══════════════════════════════════════════════════════════════════════════════════════════╝
{gray}
                                    ╭───────────╮
                                    │    {garden}    │                      {cyan}N{gray}
                                    │  GARDEN   │                  {cyan}W ──┼── E{gray}
                                    ╰─────┬─────╯                      {cyan}S{gray}
                                          │
                                          │
                                    ╭─────┴─────╮
                                    │    {alchemist}    │
                                    │ ALCHEMIST │
                                    ╰─────┬─────╯
                                          │
                                          │
    ╭───────────╮   ╭───────────╮   ╭─────┴─────╮   ╭───────────╮   ╭───────────╮   ╭───────────╮
    │    {field}    ├───┤    {farmhouse}    ├───┤    {town}    ├───┤    {guard}    ├───┤    {bridge}    ├───┤    {forest}    │
    │ FARMLAND  │   │ FARMHOUSE │   │TOWN SQUARE│   │GUARD POST │   │  BRIDGE   │   │  FOREST   │
    ╰───────────╯   ╰───────────╯   ╰─────┬─────╯   ╰─────┬─────╯   ╰───────────╯   ╰───────────╯
                                          │               │
                                          │               │
                                    ╭─────┴─────╮   ╭─────┴─────╮
                                    │    {home}    ├───┤    {shop}    │
                                    │   HOME    │   │   SHOP    │
                                    ╰───────────╯   ╰───────────╯

    {yellow}YOU ARE HERE: {Name}

    {yellow}[ ] Your location       {green}[ ] Other locations

    {cyan}─────────────────────────────────────────────────────────────────────────────────────────────{reset}
");
    }

    public void TownSquare(Player player)
    {
        if (ID == World.LOCATION_ID_TOWN_SQUARE)
        {
            Item rustySword = World.ItemByID(World.WEAPON_ID_RUSTY_SWORD);
            Item club = World.ItemByID(World.WEAPON_ID_CLUB);
            Item healingPotion = World.ItemByID(World.ITEM_ID_HEALING_POTION);
            Item bread = World.ItemByID(World.ITEM_ID_JUST_BREAD);

            Inventory.AddItemsToInventory(rustySword.Name, rustySword.ID, rustySword.Description, rustySword.Equipped, rustySword.Type, rustySword.ForBattle, rustySword.Quantity, rustySword.IsStackable, rustySword.Damage);
            Inventory.AddItemsToInventory(bread.Name, bread.ID, bread.Description, bread.Equipped, bread.Type, bread.ForBattle, bread.Quantity, bread.IsStackable,  bread.Damage);

            Console.WriteLine($"\nOn your way to Town square you found a \u001b[93m{rustySword.Name}\u001b[0m");

            GUI.PressEnter();
        }
    }
}