namespace ConsoleApp4;

public static class Battle
{
    public static void Fight(Player player, Monster monster)
    {
        while (player.IfAlive() && monster.IfAlive()) // check of speler en monster nog leven
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            int playerDamage = player.CalculateDamage();
            monster.CurrentHitPoints -= playerDamage;
            if (monster.CurrentHitPoints <0) monster.CurrentHitPoints = 0; // als het lager dan nul is word het veranderd naar nul
            if (playerDamage > 0)
            {
                Console.WriteLine($"You dealt {playerDamage} to the {monster.Name}!\nPlayer HP: {player.health.Currenthitpoints}\nMonster HP: {monster.CurrentHitPoints}");
            }
            else
            {
                Console.WriteLine($"You missed!\nPlayer HP: {player.health.Currenthitpoints}\nMonster HP: {monster.CurrentHitPoints}");
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
        if (player.IfAlive())
        {
            Console.WriteLine($"You have defeated the {monster.Name}");
        }
        else
        {
            Console.WriteLine("You lost!");
        }
    }
}