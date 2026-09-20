namespace ConsoleApp4;

public static class Inventory
{
    public static List<(string Name, int ID, string Description, bool Equiped, string Type, bool ForBattle)> inventory = new();
    public static List<(string Name, int ID, string Description, bool Equiped, string Type, bool ForBattle)> battleInventory = new();

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
            Console.WriteLine("What item would you like to remove?");
            string removeItem = Console.ReadLine();

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

    public static void AddItemsToInventory(string item, int id, string description, bool equiped, string type, bool forBattle)
    {
        inventory.Add((item, id, description, equiped, type, forBattle));
    }

    public static void AddItemsToBattleInventory(string item, int id, string description, bool equiped, string type, bool forBattle)
    {
        inventory.Add((item, id, description, equiped, type, forBattle));
    }

    public static void RemoveItemFromInventory(string item)
    {
        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.Name == item)
            {
                inventory.Remove(inventoryItem);
                return;
            }
        }

        Console.WriteLine($"{item} is not in the inventory");
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

        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.Equiped)
            {
                Console.Write($"{inventoryItem.ID}: {inventoryItem.Name} ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\u001b[3mis equipped\u001b[0m");
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
}