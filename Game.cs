namespace ConsoleApp4;

public class Game
{
    private bool playing = true;
    private int count = 0;
    private Player player;


    public void Run()
    {
        CreatePlayer();
        GenerateWorld();
        GameLoop();
        CheckGameOver();
    }


    private void CreatePlayer()
    {
        Console.Write("What is your name? ");
        string playerName = Console.ReadLine();

        player = new Player(playerName, 30, 30);

        player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

        if (playerName == "Lisa")
        {
            Item lisaAbliterator = World.ItemByID(World.ITEM_ID_LISA_ABLITERATOR);

            Inventory.AddItemsToInventory(lisaAbliterator.Name, lisaAbliterator.ID, lisaAbliterator.Description, lisaAbliterator.Equipped, lisaAbliterator.Type, lisaAbliterator.ForBattle, lisaAbliterator.Quantity, lisaAbliterator.IsStackable, lisaAbliterator.Damage);

            player.NameLisa();
        }
    }

    private void GenerateWorld()
    {
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
    }


    private void GameLoop()
    {
        while (playing && player.IfAlive())
        {
            Console.Clear();

            ShowLocation();
            ShowMenu();

            Console.Write("> ");

            string? choice = Console.ReadLine();

            HandleChoice(choice);
        }
    }


    private void ShowLocation()
    {
        GUI.CWLine($"\nYou are at: {player.CurrentLocation.Name}", ConsoleColor.Cyan);

        GUI.CWLine(player.CurrentLocation.Description, ConsoleColor.Gray);
    }


    private void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("\n1: See game stats");
        Console.WriteLine("2: Move");
        Console.WriteLine("3: Fight");
        Console.WriteLine("4: Inventory");
        Console.WriteLine("5: Talk");
        Console.WriteLine("6: Quit");

        Console.ResetColor();
    }


    private void HandleChoice(string? choice)
    {
        switch (choice)
        {
            case "1":
                ShowGameStats();
                break;

            case "2":
                MovePlayer();
                break;

            case "3":
                Fight();
                break;

            case "4":
                Inventory.inventoryMenu(player);
                break;

            case "5":
                Talk();
                break;

            case "6":
                playing = false;
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }


    private void ShowGameStats()
    {
        Console.Clear();

        GUI.CWLine("PLAYER STATUS\n", ConsoleColor.Yellow);

        GUI.CWLine("Health", ConsoleColor.DarkGray);
        GUI.CWLine($"{player.Health.Currenthitpoints}/{player.Health.Maximumhitpoints} HP\n", ConsoleColor.Green);

        GUI.CWLine("Weapon:", ConsoleColor.DarkGray);
        bool weaponEquiped = false;

        for (int i = 0; i < Inventory.inventory.Count; i++)
        {
            if (Inventory.inventory[i].Equiped)
            {
                weaponEquiped = true;

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{Inventory.inventory[i].Name} ");
                Console.ResetColor();
                Console.Write($"\u001b[91m+{Inventory.inventory[i].Damage} Attack\u001b[0m\n");
            }

            break;
        }


        if (!weaponEquiped)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("no current weapon\n");
            Console.ResetColor();
        }

        GUI.CWLine("\nActive Quest", ConsoleColor.DarkGray);

        if (player.ActiveQuests.Count == 0)
        {
            GUI.CWLine("No active quest", ConsoleColor.Gray);
        }
        else
        {
            foreach (var quest in player.ActiveQuests)
            {
                GUI.CWLine(quest.Name, ConsoleColor.Yellow);
            }
        }

        GUI.CWLine($"\nCompleted Quests ({player.CompletedQuests.Count}/3)", ConsoleColor.DarkGray);

        if (player.CompletedQuests.Count == 0)
        {
            GUI.CWLine("No quests completed yet", ConsoleColor.Gray);
        }
        else
        {
            foreach (var quest in player.CompletedQuests)
            {
                GUI.CWLine($"✓ {quest.Name}", ConsoleColor.Green);
            }
        }

        GUI.PressEnter();
    }


    private void MovePlayer()
    {
        player.MoveLocations();
        player.CurrentLocation.TownSquare(player);
    }


    private void Fight()
    {
        Console.WriteLine();

        if (player.CurrentLocation.MonsterLivingHere != null)
        {
            Monster monster =
                player.CurrentLocation.MonsterLivingHere;

            Battle.Fight(player, monster);

            if (!monster.IfAlive())
            {
                HandleMonsterDefeated(monster);

                monster.health.Heal(
                    monster.health.Maximumhitpoints
                );
            }
        }
        else
        {
            Console.WriteLine(
                "There is nothing to fight here."
            );
        }
    }


    private void HandleMonsterDefeated(Monster monster)
    {
        Quest? targetQuest = null;

        foreach (Quest quest in player.ActiveQuests)
        {
            if (quest.TargetMonsterID == monster.ID)
            {
                targetQuest = quest;
            }
        }

        if (targetQuest != null)
        {
            Console.WriteLine();

            targetQuest.RegisterKill();

            Console.WriteLine(
                $"You currently have {targetQuest.CurrentKills}/{targetQuest.RequiredKills} Kills"
            );

            if (targetQuest.IsCompleted())
            {
                player.CompletedQuests.Add(targetQuest);
                player.ActiveQuests.Remove(targetQuest);
            }
        }
    }


    private void Talk()
    {
        Console.WriteLine();

        if (count == 3)
        {
            Console.WriteLine("Are you stupid?");
            Thread.Sleep(2000);
            return;
        }

        if (player.CurrentLocation.NPCHere == null)
        {
            count++;

            Console.WriteLine(
                "There is no one here to talk to!"
            );

            Thread.Sleep(2000);

            return;
        }

        NPC npc = player.CurrentLocation.NPCHere;

        if (npc.Name == "Guard")
        {
            TalkToGuard();

            return;
        }

        TalkToQuestNPC(npc);
    }


    private void TalkToGuard()
    {
        if (player.CompletedQuests.Count >= 2)
        {
            Console.WriteLine("You may pass");
        }
        else
        {
            Console.WriteLine(
                "You have not completed enough quests to pass!"
            );
        }
    }


    private void TalkToQuestNPC(NPC npc)
    {
        if (player.CompletedQuests.Contains(npc.QuestToGive))
        {
            Console.WriteLine(
                "You have already completed this quest!"
            );
        }
        else if (!player.ActiveQuests.Contains(npc.QuestToGive))
        {
            OfferQuest(npc);
        }
        else
        {
            Console.WriteLine(
                "This quest is already active!"
            );
        }
    }


    private void OfferQuest(NPC npc)
    {
        Console.WriteLine(
            $"You have received a new quest: {npc.QuestToGive.Name}"
        );

        Console.WriteLine(
            npc.QuestToGive.Description
        );

        Console.WriteLine(
            "\nDo you want to accept the quest? (Y/N)"
        );

        string questChoice = " ";

        while (
            questChoice.ToUpper() != "Y" &&
            questChoice.ToUpper() != "N"
        )
        {
            questChoice = Console.ReadLine();
        }

        Console.WriteLine();

        if (
            questChoice.ToUpper() == "Y" &&
            player.ActiveQuests.Count < 1
        )
        {
            player.ActiveQuests.Add(
                npc.QuestToGive
            );
        }
        else if (
            questChoice.ToUpper() == "Y" &&
            player.ActiveQuests.Count >= 1
        )
        {
            Console.WriteLine(
                "You already have an active quest!"
            );
        }
        else
        {
            Console.WriteLine(
                "You have denied the quest."
            );
        }
    }


    private void CheckGameOver()
    {
        if (!player.IfAlive())
        {
            Console.WriteLine(
                "\nGame over — you have died."
            );
        }
    }
}