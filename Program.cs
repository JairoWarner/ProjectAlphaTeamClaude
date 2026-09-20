using ConsoleApp4;

Console.Write("Wat is je naam? ");
string? playerName = Console.ReadLine();

if (string.IsNullOrEmpty(playerName))
{
    playerName = "Held";
}

Player player = new Player(playerName, 30, 30);

player.CurrentWeapon =
    World.ItemByID(World.WEAPON_ID_RUSTY_SWORD);

player.CurrentLocation =
    World.LocationByID(World.LOCATION_ID_HOME);

Console.WriteLine($"\nWelkom, {player.Name}!");

bool playing = true;

while (playing && player.IfAlive())
{
    Console.WriteLine($"\nYou are at: {player.CurrentLocation.Name}");
    Console.WriteLine(player.CurrentLocation.Description);

    Console.WriteLine("\n1: See game stats");
    Console.WriteLine("2: Move");
    Console.WriteLine("3: Fight");
    Console.WriteLine("4: Inventory");
    Console.WriteLine("5: Quit");

    Console.Write("> ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine(
                $"HP: {player.health.Currenthitpoints}/{player.health.Maximumhitpoints}"
            );

            Console.WriteLine(
                $"Weapon: {player.CurrentWeapon.Name} ({player.CurrentWeapon.Damage} damage)"
            );
            break;

        case "2":
            player.MoveLocations();
            player.CurrentLocation.TownSquare(player);
            break;

        case "3":
            if (player.CurrentLocation.MonsterLivingHere != null)
            {
                Battle.Fight(
                    player,
                    player.CurrentLocation.MonsterLivingHere
                );
            }
            else
            {
                Console.WriteLine("There is nothing to fight here.");
            }

            break;

        case "4":
            Inventory.inventoryMenu();
            break;

        case "5":
            playing = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

if (!player.IfAlive())
{
    Console.WriteLine("\nGame over - you have died.");
}