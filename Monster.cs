namespace ConsoleApp4;

public class Monster
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public Health health;
    public string Special;
    public int SpecialChance;

    public Monster(
        int id,
        string name,
        int maximumdamage,
        int currenthitpoints,
        int maximumhitpoints,
        string special,
        int specialchance
    )
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumdamage;
        health = new Health(currenthitpoints, maximumhitpoints);
        Special = special;
        SpecialChance = specialchance;
    }

    public bool IfAlive()
    {
        return health.IsAlive();
    }

    public int CalculateDamage()
    {
        return World.RandomGenerator.Next(0, MaximumDamage + 1);
    }
}