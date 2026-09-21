using ConsoleApp4;

Console.Write("What is your name? ");
string playerName = Console.ReadLine();

Player player = new Player(playerName, 30, 30);

player.CurrentWeapon =
    World.ItemByID(World.WEAPON_ID_RUSTY_SWORD);

player.CurrentLocation =
    World.LocationByID(World.LOCATION_ID_HOME);

Console.Clear();
Console.WriteLine($"\u001b[33mWelcome, {player.Name}!\u001b[0m");
Console.Write("Generating World");
DateTime endTime = DateTime.Now.AddSeconds(5);

while (DateTime.Now < endTime)
{
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);

    Console.Write(".");
    Thread.Sleep(500);

    Console.Write(".");
    Thread.Sleep(500);

    Console.Write("\b\b\b   \b\b\b");
}


bool playing = true;

while (playing && player.IfAlive())
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\nYou are at: {player.CurrentLocation.Name}");

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(player.CurrentLocation.Description);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n1: See game stats");
    Console.WriteLine("2: Move");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("3: Fight");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("4: Inventory");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("5: Talk");
    Console.WriteLine("6: Quit");

    Console.ResetColor();
    
    Console.Write("> ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine($"HP: {player.Health.Currenthitpoints}/{player.Health.Maximumhitpoints}");
            Console.WriteLine($"Weapon: {player.CurrentWeapon.Name} ({player.CurrentWeapon.Damage} damage)");
            break;

        case "2":
            player.MoveLocations();
            player.CurrentLocation.TownSquare(player);
            break;

        case "3":
            if (player.CurrentLocation.MonsterLivingHere != null)
            {
                Monster monster = player.CurrentLocation.MonsterLivingHere;
                Battle.Fight(player, monster);

                if (!monster.IfAlive())
                {
                    Quest TargetQuest = null;
                    foreach (Quest quest in player.ActiveQuests)
                    {
                        if (quest.TargetMonsterID == monster.ID)
                        {
                            TargetQuest = quest;
                        }
                    }
                    if (TargetQuest != null)
                    {
                        TargetQuest.RegisterKill();
                        Console.WriteLine($"You currently have {TargetQuest.CurrentKills}/{TargetQuest.RequiredKills} Kills");

                        if (TargetQuest.IsCompleted())
                        {
                            player.CompletedQuests.Add(TargetQuest);
                            player.ActiveQuests.Remove(TargetQuest);
                        }
                    }
                    monster.health.Heal(monster.health.Maximumhitpoints);
                }
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
            if (player.CurrentLocation.NPCHere == null)
            {
                Console.WriteLine("There is no one here to talk to!");
            }
            else
            {
                NPC npc = player.CurrentLocation.NPCHere;
                if (player.CompletedQuests.Contains(npc.QuestToGive))
                {
                    Console.WriteLine("You have already completed this quest!");
                }
                else if (!player.ActiveQuests.Contains(npc.QuestToGive))
                {
                    Console.WriteLine($"You have received a new quest: {npc.QuestToGive.Name}");
                    Console.WriteLine(npc.QuestToGive.Description);
                    Console.WriteLine("Do you want to accept the quest? (Y/N)");
                    string questChoice = " ";
                    while (questChoice.ToUpper() != "Y" && questChoice.ToUpper() != "N")
                    {
                        questChoice = Console.ReadLine();
                    }
                    if (questChoice.ToUpper() == "Y")
                        player.ActiveQuests.Add(npc.QuestToGive);
                    else
                    {
                        Console.WriteLine("You have denied the quest.");
                    }
                }
                else
                {
                    Console.WriteLine("This quest is already active!");
                }

            }
            break;
        case "6":
            playing = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

if (!player.IfAlive())
{
    Console.WriteLine("\nGame over — you have died.");
}