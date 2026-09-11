namespace ConsoleApp4;

public class Player
{
    public string Name;
    public Health health;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;

    public Player(string name, int currenthitpoints, int maximumhitpoints)
    {
        Name = name;
        health = new Health(currenthitpoints, maximumhitpoints);
        CurrentWeapon = null;
        CurrentLocation = null;
    }

    public bool IfAlive()
    {
        return health.IsAlive();
    }

    public void Heal(int amount)
    {
        health.Heal(amount);
    }
    public int CalculateDamage()
    {
        return World.RandomGenerator.Next(0, CurrentWeapon.Damage + 1);
    }



}