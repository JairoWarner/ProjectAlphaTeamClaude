namespace ConsoleApp4;

public static class Battle
{
    public static bool isActive = false;

    public static void Fight(Player player, Monster monster)
    {
        bool hasFled = false;

        while (player.IfAlive() && monster.IfAlive())
        {
            isActive = true;

            Console.WriteLine();
            List<string> choiceMenu = new(["A", "F", "I"]);
            string choice = " ";

            while (!choiceMenu.Contains(choice.ToUpper()))
            {
                Console.WriteLine("A: Attack");
                Console.WriteLine("F: Flee");
                Console.WriteLine("I: Inventory");
                choice = Console.ReadLine();
            }

            Console.WriteLine();

            if (choice.ToUpper() == "A")
            {
                int playerDamage = player.CalculateDamage();
                monster.health.TakeDamage(playerDamage);

                if (playerDamage > 0)
                {
                    Console.WriteLine($"You dealt {playerDamage} damage to the {monster.Name}!\nPlayer HP: {player.Health.Currenthitpoints}\nMonster HP: {monster.health.Currenthitpoints}");
                }
                else
                {
                    Console.WriteLine($"You missed!\nPlayer HP: {player.Health.Currenthitpoints}\nMonster HP: {monster.health.Currenthitpoints}");
                }
            }

            else if (choice.ToUpper() == "F")
            {
                if (player.Health.Currenthitpoints >= 10)
                {
                    hasFled = true;
                    break;
                }
                else
                {
                    Console.WriteLine("You need more HP to flee!");
                }
            }

            else if (choice.ToUpper() == "I")
            {
                Console.WriteLine();
                Console.WriteLine("1: Check Inventory");
                Console.WriteLine("2: Use Item");
                Console.WriteLine("3: Go Back");

                int Choice = int.Parse(Console.ReadLine());

                if (Choice == 1)
                {
                    Console.WriteLine();
                    Inventory.GetInventory();
                    Console.WriteLine("\npress ENTER to go back.");
                    Console.ReadLine();
                    continue;
                }

                if (Choice == 2)
                {
                    Console.WriteLine();
                    Inventory.GetInventory();

                    Console.WriteLine("\nType the ID of the item you want to use:");
                    int itemID = int.Parse(Console.ReadLine());

                    Inventory.UseItem(itemID, player);
                }

                if (Choice == 3)
                {
                    continue;
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.WriteLine();

            if (monster.IfAlive())
            {
                int monsterDamage = monster.CalculateDamage();
                player.Health.TakeDamage(monsterDamage);

                if (monsterDamage > 0)
                {
                    Console.WriteLine($"The Monster dealt {monsterDamage} damage to the you!\nPlayer HP: {player.Health.Currenthitpoints}\nMonster HP: {monster.health.Currenthitpoints}");
                }
                else
                {
                    Console.WriteLine($"The monster missed!\nPlayer HP: {player.Health.Currenthitpoints}\nMonster HP: {monster.health.Currenthitpoints}");
                }
            }
        }

        Console.WriteLine();

        if (player.IfAlive() && hasFled == false)
        {
            Console.WriteLine($"You have defeated the {monster.Name}");
        }
        else if (player.IfAlive() && hasFled == true)
        {
            Console.WriteLine("You have fled!");
        }
        else
        {
            Console.WriteLine("You lost!");
        }

        isActive = false;
    }
}