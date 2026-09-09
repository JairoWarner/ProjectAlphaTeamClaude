class Player
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

    //if (player.Health.IsAlive())
    //player.Health.TakeDamage(10);

}