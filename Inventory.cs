namespace ConsoleApp4;

public static class Inventory
{
    public static List<(string Name, int ID, string Description, bool Equiped, string Type, bool ForBattle, int Quantity)> inventory = new();
    public static List<(string Name, int ID, string Description, bool Equiped, string Type, bool ForBattle, int Quantity)> battleInventory = new();

    public static void inventoryMenu()
    {
        Console.Clear();
        Console.WriteLine("1: View inventory");
        Console.WriteLine("2: Remove item");
        Console.WriteLine("3: Check description");
        Console.WriteLine("4: Equip weapon");
        Console.WriteLine("5: Go back");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Clear();
            GetInventory();
            Console.WriteLine("Type ENTER to continue");
            Console.ReadLine();
        }

        if (choice == "2")
        {
            GetInventory();
            Console.WriteLine("What item would you like to remove?");
            int removeItem = int.Parse(Console.ReadLine());

            RemoveItemFromInventory(removeItem);
        }

        if (choice == "3")
        {
            GetInventory();

            Console.WriteLine("Type an item ID to see its description:");
            int itemID = int.Parse(Console.ReadLine());

            CheckDescription(itemID);
        }

        if (choice == "4")
        {
            GetInventory();

            Console.WriteLine("Type the weapon ID that you want to Equip:");
            int weaponID = int.Parse(Console.ReadLine());

            EquipWeapon(weaponID);
        }

        if (choice == "5")
        {
            return;
        }
    }

    public static void AddItemsToInventory(string item, int id, string description, bool equiped, string type, bool forBattle, int quantity, bool isStackable)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ID  == id)
            {
                if (!isStackable)
                    return;
                
                var inventoryItem = inventory[i];
                inventoryItem.Quantity++;
                inventory[i] =  inventoryItem;
                
                if (forBattle)
                {
                    for (int j = 0; j < battleInventory.Count; j++)
                    {
                        if (battleInventory[j].ID == id)
                        {
                            var battleItem = battleInventory[j];
                            battleItem.Quantity++;
                            battleInventory[j] = battleItem;
                            break;
                        }
                    }
                }

                return;
            }
        }

        inventory.Add((item, id, description, equiped, type, forBattle, 1));

        if (forBattle)
        {
            battleInventory.Add((item, id, description, equiped, type, forBattle, 1));
        }
    }

    public static void RemoveItemFromInventory(int itemID)
    {
        int counter = 0;
        for (int i = 0;  i < inventory.Count; i++)
        {
            if (inventory[i].ID == 5)
            {
                foreach (string text in BreadStorys.breadStory1)
                {
                    Console.WriteLine(text);
                    Console.ReadLine();
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            if (inventory[i].ID == itemID)
            {
                inventory.Remove(inventory[i]);
                return;
            }
        }

        Console.WriteLine($"{itemID} is not in the inventory");
    }

    public static void CheckDescription(int item)
    {
        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.ID == item)
            {
                if (inventoryItem.ForBattle)
                {
                    Console.WriteLine($"{inventoryItem.Description} This item can be used in battle!");
                }
                else
                {
                    Console.WriteLine(inventoryItem.Description);
                }

                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                return;
            }
        }

        Console.WriteLine("Player doesn't own that item");
    }

    public static void GetInventory()
    {
        Console.Clear();
        if (Battle.isActive == false)
        {
            foreach (var inventoryItem in inventory)
            {
                if (inventoryItem.Equiped)
                {
                    Console.Write($"{inventoryItem.ID}: {inventoryItem.Name} x{inventoryItem.Quantity}");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\u001b[3mis equipped\u001b[0m");
                    Console.ResetColor();

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{inventoryItem.ID}: {inventoryItem.Name} x{inventoryItem.Quantity}");
                }
            }

            return;
        }

        if (Battle.isActive)
        {
            foreach (var inventoryItem in battleInventory)
            {
                if (inventoryItem.Equiped)
                {
                    Console.Write($"{inventoryItem.ID}: {inventoryItem.Name} x{inventoryItem.Quantity}");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\u001b[3mis equipped\u001b[0m");
                    Console.ResetColor();

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{inventoryItem.ID}: {inventoryItem.Name} x{inventoryItem.Quantity}");
                }
            }

            return;
        }

        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.Equiped)
            {
                Console.Write($"{inventoryItem.ID}: {inventoryItem.Name} ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" \u001b[3mis equipped\u001b[0m");
                Console.ResetColor();

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{inventoryItem.ID}: {inventoryItem.Name}");
            }
        }
    }

    public static void EquipWeapon(int item)
    {
        Console.Clear();

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Type == "weapon")
            {
                var inventoryItem = inventory[i];

                if (inventory[i].ID == item)
                {
                    inventoryItem.Equiped = true;
                }
                else
                {
                    inventoryItem.Equiped = false;
                }

                inventory[i] = inventoryItem;
            }
        }

        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.Equiped)
            {
                Console.WriteLine($"{inventoryItem.Name} is equipped");
                return;
            }
        }
    }

    public static void UseItem(int itemID, Player player)
    {
        for (int i = 0; i < battleInventory.Count; i++)
        {
            if (battleInventory[i].ID == itemID)
            {
                Item item = World.ItemByID(itemID);
                var inventoryItem = battleInventory[i];
    
                if (inventoryItem.Type == "healing potion")
                {
                    player.Heal(item.HealingValue);
    
                    Console.WriteLine($"You used {item.Name}.");
                    Console.WriteLine($"You healed {item.HealingValue} HP.");
                    Console.WriteLine($"Current HP: {player.Health.Currenthitpoints}/{player.Health.Maximumhitpoints}");
    
                    inventoryItem.Quantity--;
    
                    if (inventoryItem.Quantity <= 0)
                    {
                        battleInventory.RemoveAt(i);
    
                        for (int j = 0; j < inventory.Count; j++)
                        {
                            if (inventory[j].ID == itemID)
                            {
                                inventory.RemoveAt(j);
                                break;
                            }
                        }
                    }
                    else
                    {
                        battleInventory[i] = inventoryItem;
                    }
    
                    return;
                }
    
                if (inventoryItem.Type == "strength potion")
                {
                    player.CurrentWeapon.Damage += item.HealingValue;
    
                    Console.WriteLine($"You used {item.Name}.");
                    Console.WriteLine($"Your attack damage increased by {item.HealingValue}.");
    
                    inventoryItem.Quantity--;
    
                    if (inventoryItem.Quantity <= 0)
                    {
                        battleInventory.RemoveAt(i);
    
                        for (int j = 0; j < inventory.Count; j++)
                        {
                            if (inventory[j].ID == itemID)
                            {
                                inventory.RemoveAt(j);
                                break;
                            }
                        }
                    }
                    else
                    {
                        battleInventory[i] = inventoryItem;
                    }
    
                    return;
                }
            }
        }
    }
}