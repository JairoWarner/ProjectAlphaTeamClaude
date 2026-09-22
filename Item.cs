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
    public int Quantity;
    public bool IsStackable;

    public Item(
        int id,
        string name,
        int damage,
        int healingValue,
        string description,
        bool equipped,
        string type,
        bool forBattle,
        int quantity,
        bool isStackable)
    {
        ID = id;
        Name = name;
        Damage = damage;
        HealingValue = healingValue;
        Description = description;
        Equipped = equipped;
        Type = type;
        ForBattle = forBattle;
        Quantity = quantity;
        IsStackable = isStackable;
    }

    public void Attack(Health target)
    {
        target.TakeDamage(Damage);
    }
    
    public void UseHealingPotion(Player player, int inventoryIndex)
    {
        player.Heal(HealingValue);

        Console.WriteLine($"You used {Name}.");
        Console.WriteLine($"You healed {HealingValue} HP.");
        Console.WriteLine(
            $"Current HP: {player.Health.Currenthitpoints}/{player.Health.Maximumhitpoints}"
        );

        var inventoryItem = Inventory.battleInventory[inventoryIndex];

        inventoryItem.Quantity--;

        if (inventoryItem.Quantity <= 0)
        {
            Inventory.battleInventory.RemoveAt(inventoryIndex);

            for (int j = 0; j < Inventory.inventory.Count; j++)
            {
                if (Inventory.inventory[j].ID == ID)
                {
                    Inventory.inventory.RemoveAt(j);
                    break;
                }
            }
        }
        else
        {
            Inventory.battleInventory[inventoryIndex] = inventoryItem;
        }
    }
    
    public void UseStrengthPotion(Player player, int inventoryIndex)
    {
        if (player.CurrentWeapon == null)
        {
            Console.WriteLine("You need to equip a weapon first.");
            return;
        }

        player.CurrentWeapon.Damage += HealingValue;

        Console.WriteLine($"You used {Name}.");
        Console.WriteLine(
            $"Your attack damage increased by {HealingValue}."
        );

        var inventoryItem = Inventory.battleInventory[inventoryIndex];

        inventoryItem.Quantity--;

        if (inventoryItem.Quantity <= 0)
        {
            Inventory.battleInventory.RemoveAt(inventoryIndex);

            for (int j = 0; j < Inventory.inventory.Count; j++)
            {
                if (Inventory.inventory[j].ID == ID)
                {
                    Inventory.inventory.RemoveAt(j);
                    break;
                }
            }
        }
        else
        {
            Inventory.battleInventory[inventoryIndex] = inventoryItem;
        }
    }
}