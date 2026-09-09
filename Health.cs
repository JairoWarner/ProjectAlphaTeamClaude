public class Health
{
    public int Currenthitpoints;
    public int Maximumhitpoints;

    public Health(int currenthitpoints, int maximumhitpoints)
    {
        Currenthitpoints = currenthitpoints;
        Maximumhitpoints = maximumhitpoints;
    }

    public void TakeDamage(int damage)
    {
        Currenthitpoints -= damage;

        if (Currenthitpoints < 0)
        {
            Currenthitpoints = 0;
        }
    }

    public void Heal(int amount)
    {
        Currenthitpoints += amount;

        if (Currenthitpoints > Maximumhitpoints)
        {
            Currenthitpoints = Maximumhitpoints;
        }
    }
    public void IncreaseMaximumHealth(int amount)
    {
    Maximumhitpoints += amount;
    }

    public bool IsAlive()
    {
        return Currenthitpoints > 0;
    }
}