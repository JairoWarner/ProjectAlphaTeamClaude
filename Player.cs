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

<<<<<<< HEAD
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
=======
    //if (player.Health.IsAlive())
    //player.Health.TakeDamage(10);
>>>>>>> 30d308dd2b9b90a502e6c7c9c6f6c4173e895d71

}