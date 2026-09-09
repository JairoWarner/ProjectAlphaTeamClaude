public class Monster
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public string Special;
    public int SpecialChance;

    public Monster(int id, string name, int maximumdamage, int currenthitpoints, int maximumhitpoints, string special, int specialchance)
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumdamage;
        CurrentHitPoints = currenthitpoints;
        MaximumHitPoints = maximumhitpoints;
        Special = special;
        SpecialChance = specialchance;
    }
}