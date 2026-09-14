public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public int RequiredKills;

    public Quest(int id, string name, string description, int requiredKills)
    {
        ID = id;
        Name = name;
        Description = description;
        RequiredKills = requiredKills;
        iscompleted = false;
    }
}