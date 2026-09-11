namespace ConsoleApp4;

public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;

    public Player(string name, int currenthitpoints, int maximumhitpoints)
    {
        Name = name;
        CurrentHitPoints = currenthitpoints;
        MaximumHitPoints = maximumhitpoints;
        CurrentWeapon = null;
        CurrentLocation = null;
    }

    public bool IfAlive()
    {
        return CurrentHitPoints > 0;
    }

    public void Heal(int amount)
    {
        CurrentHitPoints += amount;
        if (CurrentHitPoints > MaximumHitPoints)
        {
            CurrentHitPoints = MaximumHitPoints;
        }
    }
    public int CalculateDamage()
    {
        return World.RandomGenerator.Next(0, CurrentWeapon.Damage + 1);
    }

}