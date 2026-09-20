namespace ConsoleApp4;

public class Item
{
    public int ID;
    public string Name;
    public int Damage;
    public int HealingValue;
    public string Description;
    public bool Equipped;
    public string Type;
    public bool ForBattle;

    public Item(
        int id,
        string name,
        int damage,
        int healingValue,
        string description,
        bool equipped,
        string type,
        bool forBattle)
    {
        ID = id;
        Name = name;
        Damage = damage;
        HealingValue = healingValue;
        Description = description;
        Equipped = equipped;
        Type = type;
        ForBattle = forBattle;
    }

    public void Attack(Health target)
    {
        target.TakeDamage(Damage);
    }
}