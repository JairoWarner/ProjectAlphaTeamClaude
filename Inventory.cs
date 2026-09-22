namespace ConsoleApp4;

public static class Inventory
{
    public static List<(string Name, int ID, string Description, bool Equiped, string Type, bool ForBattle, int Quantity, int Damage)> inventory = new();
    public static List<(string Name, int ID, string Description, bool Equiped, string Type, bool ForBattle, int Quantity, int Damage)> battleInventory = new();

    public static void inventoryMenu(Player player)
    {
        Console.Clear();

        GUI.CWLine("INVENTORY", ConsoleColor.Yellow);
        Console.WriteLine();

        GUI.CWLine("[1] View inventory", ConsoleColor.Green);
        GUI.CWLine("[2] Remove item", ConsoleColor.Green);
        GUI.CWLine("[3] Check description", ConsoleColor.Green);
        GUI.CWLine("[4] Equip weapon", ConsoleColor.Green);
        GUI.CWLine("[Q] Go back", ConsoleColor.Red);

        string choice = "";

        while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice.ToUpper() != "Q")
        {
            Console.Write("\nChoice: ");
            choice = Console.ReadLine();

            if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice.ToUpper() != "Q")
            {
                Console.WriteLine("Please enter 1, 2, 3, 4 or Q.");
            }
        }

        if (choice == "1")
        {
            Console.Clear();
            GetInventory();
            GUI.PressEnter();
        }

        if (choice == "2")
        {
            GetInventory();

            string input = GetValidInput("What item would you like to remove?");

            if (input.ToUpper() == "Q")
            {
                return;
            }

            int removeItem = int.Parse(input);

            RemoveItemFromInventory(removeItem);
        }

        if (choice == "3")
        {
            GetInventory();

            string input = GetValidInput("Type an item ID to see its description:");

            if (input.ToUpper() == "Q")
            {
                return;
            }

            int itemID = int.Parse(input);

            CheckDescription(itemID);
        }

        if (choice == "4")
        {
            GetInventory();

            string input = GetValidInput("Type the weapon ID that you want to equip:");

            if (input.ToUpper() == "Q")
            {
                return;
            }

            int weaponID = int.Parse(input);

            EquipWeapon(weaponID, player);
        }

        if (choice.ToUpper() == "Q")
        {
            return;
        }
    }

    private static string GetValidInput(string message)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            GUI.CWLine("[Q] Go back", ConsoleColor.Red);
            Console.Write("\nChoice: ");

            string input = Console.ReadLine();

            if (input.ToUpper() == "Q")
            {
                return input;
            }

            if (int.TryParse(input, out int number))
            {
                return input;
            }

            Console.Clear();
            Console.WriteLine("Please enter a valid item ID or Q to go back.");
        }
    }

    public static void AddItemsToInventory(string item, int id, string description, bool equiped, string type, bool forBattle, int quantity, bool isStackable, int damage)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ID == id)
            {
                if (!isStackable)
                    return;

                var inventoryItem = inventory[i];
                inventoryItem.Quantity++;
                inventory[i] = inventoryItem;

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

        inventory.Add((item, id, description, equiped, type, forBattle, 1, damage));

        if (forBattle)
        {
            battleInventory.Add((item, id, description, equiped, type, forBattle, 1, damage));
        }
    }

    public static void RemoveItemFromInventory(int itemID)
    {
        int counter = 0;

        for (int i = 0; i < inventory.Count; i++)
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
                Console.Clear();

                GUI.CWLine(inventoryItem.Name, ConsoleColor.Yellow);
                Console.WriteLine();

                if (inventoryItem.ForBattle)
                {
                    Console.WriteLine($"{inventoryItem.Description}");
                    GUI.CWLine("This item can be used in battle!", ConsoleColor.Green);
                }
                else
                {
                    Console.WriteLine(inventoryItem.Description);
                }

                GUI.PressEnter();
                return;
            }
        }

        Console.WriteLine("Player doesn't own that item");
    }

    public static void GetInventory()
    {
        Console.Clear();

        GUI.CWLine("INVENTORY", ConsoleColor.Yellow);
        Console.WriteLine();

        if (Battle.isActive == false)
        {
            if (inventory.Count == 0)
            {
                GUI.CWLine("Your inventory is empty.", ConsoleColor.DarkGray);
                return;
            }

            foreach (var inventoryItem in inventory)
            {
                if (inventoryItem.Equiped)
                {
                    Console.Write($"{inventoryItem.ID}: {inventoryItem.Name} x{inventoryItem.Quantity}");

                    GUI.CWLine(" - is equipped", ConsoleColor.Green);

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
            if (battleInventory.Count == 0)
            {
                GUI.CWLine("You have no battle items.", ConsoleColor.DarkGray);
                return;
            }

            foreach (var inventoryItem in battleInventory)
            {
                if (inventoryItem.Equiped)
                {
                    Console.Write($"{inventoryItem.ID}: {inventoryItem.Name} x{inventoryItem.Quantity}");

                    GUI.CWLine(" - is equipped", ConsoleColor.Green);

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

                GUI.CWLine(" - is equipped", ConsoleColor.Green);

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{inventoryItem.ID}: {inventoryItem.Name}");
            }
        }
    }

    public static void EquipWeapon(int item, Player player)
    {
        Console.Clear();

        player.CurrentWeapon = null;

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Type == "weapon")
            {
                var inventoryItem = inventory[i];

                if (inventory[i].ID == item)
                {
                    inventoryItem.Equiped = true;
                    player.CurrentWeapon = World.ItemByID(inventory[i].ID);
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
                GUI.CWLine($"{inventoryItem.Name} is equipped.", ConsoleColor.Green);
                return;
            }
        }

        Console.WriteLine("You don't own a weapon with that ID.");
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
                    item.UseHealingPotion(player, i);
                    return;
                }

                if (inventoryItem.Type == "strength potion")
                {
                    item.UseStrengthPotion(player, i);
                    return;
                }
            }
        }
    }
}