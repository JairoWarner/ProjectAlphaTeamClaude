namespace ConsoleApp4;

public static class World
{

    public static readonly List<Item> Items = new List<Item>();
    public static readonly List<Monster> Monsters = new List<Monster>();
    public static readonly List<Quest> Quests = new List<Quest>();
    public static readonly List<Location> Locations = new List<Location>();
    public static readonly Random RandomGenerator = new Random();

    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;

    public const int ITEM_ID_HEALING_POTION = 3;
    public const int ITEM_ID_STRENGTH_POTION = 4;
    public const int ITEM_ID_JUST_BREAD = 5;

    public const int MONSTER_ID_RAT = 1;
    public const int MONSTER_ID_SNAKE = 2;
    public const int MONSTER_ID_GIANT_SPIDER = 3;

    public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
    public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
    public const int QUEST_ID_COLLECT_SPIDER_SILK = 3;

    public const int LOCATION_ID_HOME = 1;
    public const int LOCATION_ID_TOWN_SQUARE = 2;
    public const int LOCATION_ID_GUARD_POST = 3;
    public const int LOCATION_ID_ALCHEMIST_HUT = 4;
    public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
    public const int LOCATION_ID_FARMHOUSE = 6;
    public const int LOCATION_ID_FARM_FIELD = 7;
    public const int LOCATION_ID_BRIDGE = 8;
    public const int LOCATION_ID_SPIDER_FIELD = 9;
    public const int LOCATION_ID_SHOP = 10;

    static World()
    {
        PopulateItems();
        PopulateMonsters();
        PopulateQuests();
        PopulateLocations();
        NPC.PopulateNPCs();
    }

    public static void PopulateItems()
    {
        Items.Add(new Item(WEAPON_ID_RUSTY_SWORD, "Rusty sword", 5, 0, "An old sword covered in rust. Not pretty, but it still gets the job done.", false, "weapon", false, 0, false));
        Items.Add(new Item(WEAPON_ID_CLUB, "Club", 10, 0, "A thick wooden club that hits harder than it looks.", false, "weapon", false, 0, false));
        Items.Add(new Item(ITEM_ID_HEALING_POTION, "Healing potion", 0, 5, "Good soup.", false, "healing potion", true, 0, true));
        Items.Add(new Item(ITEM_ID_STRENGTH_POTION, "Strength potion", 0, 5, "Gooder soup.", false, "strength potion", true, 0, true));
        Items.Add(new Item(ITEM_ID_JUST_BREAD, "Just bread", 0, 0, "The developers needed an item to test whether it would stay out of the battle inventory, so now you have Just Bread. It's not disposable, it's not edible, and it refuses to leave. Congratulations, this bread is now your permanent companion.", false, "bread", false, 0, false));
    }

    public static void PopulateMonsters()
    {
        Monster rat = new Monster(MONSTER_ID_RAT, "rat", 1, 3, 3, "Critical Hit", 10);


        Monster snake = new Monster(MONSTER_ID_SNAKE, "snake", 10, 7, 7, null, 0);


        Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "giant spider", 3, 10, 10, "Poison", 15);


        Monsters.Add(rat);
        Monsters.Add(snake);
        Monsters.Add(giantSpider);
    }

    public static void PopulateQuests()
    {
        Quest clearAlchemistGarden =
            new Quest(
                QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                "Clear the alchemist's garden",
                "Kill rats in the alchemist's garden ", 3, MONSTER_ID_RAT);



        Quest clearFarmersField =
            new Quest(
                QUEST_ID_CLEAR_FARMERS_FIELD,
                "Clear the farmer's field",
                "Kill snakes in the farmer's field", 3, MONSTER_ID_SNAKE);


        Quest clearSpidersForest =
                    new Quest(
                        QUEST_ID_COLLECT_SPIDER_SILK,
                        "Collect spider silk",
                        "Kill spiders in the spider forest", 3, MONSTER_ID_GIANT_SPIDER);


        Quests.Add(clearAlchemistGarden);
        Quests.Add(clearFarmersField);
        Quests.Add(clearSpidersForest);
    }

    public static void PopulateLocations()
    {
        // Create each location
        Location home = new Location(LOCATION_ID_HOME, "Home", "Damn its a mess, you really need to clean up the place.", null, null, null, null);

        Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain. in the middle of the square.", null, null, null, null);

        Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves. The alchemist is busy brewing a potion.", null, null, null, null);

        Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here. You notice several rats scurrying between the plants.", null, null, null, null);
        alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

        Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "this farmhouse does look cute! a farmer is in front.", null, null, null, null);

        Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.", null, null, null, null);
        farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

        Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here. maybe he can help you.", null, null, null, null);

        Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "The stone bridge crosses a wide river. that does seem like a good place to cross.", null, null, null, null);

        Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering the trees in this forest. weird sounds are everywhere....", null, null, null, null);
        spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

        Location Shop = new Location(LOCATION_ID_SHOP, "Shop", "As you enter the shop you see the shopowner polishing his till.", null, null, null, null);

        // Link the locations together
        home.LocationToNorth = townSquare;
        home.LocationToEast = Shop;

        townSquare.LocationToNorth = alchemistHut;
        townSquare.LocationToSouth = home;
        townSquare.LocationToEast = guardPost;
        townSquare.LocationToWest = farmhouse;

        farmhouse.LocationToEast = townSquare;
        farmhouse.LocationToWest = farmersField;

        farmersField.LocationToEast = farmhouse;

        alchemistHut.LocationToSouth = townSquare;
        alchemistHut.LocationToNorth = alchemistsGarden;

        alchemistsGarden.LocationToSouth = alchemistHut;

        guardPost.LocationToEast = bridge;
        guardPost.LocationToWest = townSquare;
        guardPost.LocationToSouth = Shop;

        bridge.LocationToWest = guardPost;
        bridge.LocationToEast = spiderField;

        spiderField.LocationToWest = bridge;

        Locations.Add(home);
        Locations.Add(townSquare);
        Locations.Add(guardPost);
        Locations.Add(alchemistHut);
        Locations.Add(alchemistsGarden);
        Locations.Add(farmhouse);
        Locations.Add(farmersField);
        Locations.Add(bridge);
        Locations.Add(spiderField);
        Locations.Add(Shop);
    }

    public static Location LocationByID(int id)
    {
        foreach (Location location in Locations)
        {
            if (location.ID == id)
            {
                return location;
            }
        }

        return null;
    }

    public static Item ItemByID(int id)
    {
        foreach (Item item in Items)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }



    public static Monster MonsterByID(int id)
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.ID == id)
            {
                return monster;
            }
        }

        return null;
    }

    public static Quest QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }
}