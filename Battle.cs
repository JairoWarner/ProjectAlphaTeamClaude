namespace ConsoleApp4;

public static class Battle
{
    public static void Fight(Player player, Monster monster)
    {
        bool hasFled = false;
        while (player.IfAlive() && monster.IfAlive()) // check of speler en monster nog leven
        {
            List<string> choiceMenu = new(["A", "F", "I"]);
            string choice = " ";
            while (!choiceMenu.Contains(choice.ToUpper()))
            {
                Console.WriteLine("A: Attack");
                Console.WriteLine("F: Flee");
                Console.WriteLine("I: Inventory");
                choice = Console.ReadLine();
            }
            if (choice.ToUpper() == "A")
            {
                int playerDamage = player.CalculateDamage();
                monster.CurrentHitPoints -= playerDamage;
                if (monster.CurrentHitPoints < 0) monster.CurrentHitPoints = 0; // als het lager dan nul is word het veranderd naar nul

                if (playerDamage > 0)
                {
                    Console.WriteLine($"You dealt {playerDamage} to the {monster.Name}!\nPlayer HP: {player.health.Currenthitpoints}\nMonster HP: {monster.CurrentHitPoints}");
                }
                else
                {
                    Console.WriteLine($"You missed!\nPlayer HP: {player.health.Currenthitpoints}\nMonster HP: {monster.CurrentHitPoints}");
                }
            }
            else if (choice.ToUpper() == "F")
            {
                if (player.health.Currenthitpoints >= 10)
                {
                    hasFled = true;
                    break;
                }
                else
                {
                    Console.WriteLine("You need more HP to flee!");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            if (monster.IfAlive()) // check of het monster nog leeft anders kan er aangevallen worden terwijl die al dood is
            {
                int monsterDamage = monster.CalculateDamage();
                player.health.TakeDamage(monsterDamage);
                if (monsterDamage > 0)
                {
                    Console.WriteLine($"The Monster dealt {monsterDamage} to the you!\nPlayer HP: {player.health.Currenthitpoints}\nMonster HP: {monster.CurrentHitPoints}");
                }
                else
                {
                    Console.WriteLine($"The monster missed!\nPlayer HP: {player.health.Currenthitpoints}\nMonster HP: {monster.CurrentHitPoints}");
                }
            }
        }
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
    }
}
