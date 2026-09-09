public class Weapon
{
    public int ID;
    public string Name;
    public int Damage;

    public Weapon(int weaponId, string weaponName, int weaponDamage)
    {
        ID = weaponId;
        Name = weaponName;
        Damage = weaponDamage;
    }

    public void Attack(Health target)
    {
        target.TakeDamage(Damage);
    }
}