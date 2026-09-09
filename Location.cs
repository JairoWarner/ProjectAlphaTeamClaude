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
}
