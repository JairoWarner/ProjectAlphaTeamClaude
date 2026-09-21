using ConsoleApp4;

Console.Write("What is your name? ");
string playerName = Console.ReadLine();

Player player = new Player(playerName, 30, 30);
player.CurrentWeapon = World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD);
player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

Console.WriteLine($"\nWelcome, {player.Name}!");

bool playing = true;
while (playing && player.IfAlive())
{
    Console.WriteLine($"\nYou are at: {player.CurrentLocation.Name}");
    Console.WriteLine(player.CurrentLocation.Description);
    Console.WriteLine("\n1: See game stats");
    Console.WriteLine("2: Move");
    Console.WriteLine("3: Fight");
    Console.WriteLine("4: Talk");
    Console.WriteLine("5: Quit");
    Console.Write("> ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine();
            Console.WriteLine($"HP: {player.health.Currenthitpoints}/{player.health.Maximumhitpoints}");
            Console.WriteLine($"Weapon: {player.CurrentWeapon.Name} ({player.CurrentWeapon.Damage} damage)\n");
            foreach (var quest in player.ActiveQuests)
                Console.WriteLine($"Active Quest:\n{quest.Name}\n");
            Console.WriteLine($"Completed Quest ({player.CompletedQuests.Count}/3):");
            foreach (var quest in player.CompletedQuests)
                Console.WriteLine(quest.Name);

            break;

        case "2":
            player.MoveLocations();
            break;

        case "3":
            Console.WriteLine();
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
                        Console.WriteLine();
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
            Console.WriteLine();
            if (player.CurrentLocation.NPCHere == null)
            {
                Console.WriteLine("There is no one here to talk to!");
            }
            else
            {
                NPC npc = player.CurrentLocation.NPCHere;
                if (npc.Name == "Guard")
                {
                    if (player.CompletedQuests.Count >= 2)
                    {
                        Console.WriteLine("You may pass");
                    }
                    else
                    {
                        Console.WriteLine("You have not completed enough quests to pass!");
                    }
                }
                else
                {
                    if (player.CompletedQuests.Contains(npc.QuestToGive))
                    {
                        Console.WriteLine("You have already completed this quest!");
                    }
                    else if (!player.ActiveQuests.Contains(npc.QuestToGive))
                    {
                        Console.WriteLine($"You have received a new quest: {npc.QuestToGive.Name}");
                        Console.WriteLine(npc.QuestToGive.Description);
                        Console.WriteLine("\nDo you want to accept the quest? (Y/N)");
                        string questChoice = " ";
                        while (questChoice.ToUpper() != "Y" && questChoice.ToUpper() != "N")
                        {
                            questChoice = Console.ReadLine();
                        }
                        Console.WriteLine();
                        if (questChoice.ToUpper() == "Y" && player.ActiveQuests.Count < 1)
                        {
                            player.ActiveQuests.Add(npc.QuestToGive);
                        }
                        else if (questChoice.ToUpper() == "Y" && player.ActiveQuests.Count >= 1)
                        {
                            Console.WriteLine("You already have an active quest!");
                        }
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
            }
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
    Console.WriteLine("\nGame over — you have died.");
}