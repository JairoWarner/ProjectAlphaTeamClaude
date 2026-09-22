using System.Xml.Schema;

namespace ConsoleApp4;

public class Player
{
    public string Name;
    public Health Health;
    public Item? CurrentWeapon;
    public Location CurrentLocation;
    public List<Quest> ActiveQuests = new([]);
    public List<Quest> CompletedQuests = new([]);

    public Player(string name, int currenthitpoints, int maximumhitpoints)
    {
        Name = name;
        Health = new Health(currenthitpoints, maximumhitpoints);
        CurrentWeapon = null;
        CurrentLocation = null;
    }

    public bool IfAlive()
    {
        return Health.IsAlive();
    }

    public void Heal(int amount)
    {
        Health.Heal(amount);
    }

    public int CalculateDamage()
    {
        if (CurrentWeapon == null)
        {
            return 2;
        }

        return World.RandomGenerator.Next(0, CurrentWeapon.Damage + 1);
    }

    public void MoveLocations()
    {
        bool moving = false;
        string moving_to = "";
        string confirmation = "";

        CurrentLocation.ShowMap();
        Console.WriteLine();
        Console.WriteLine($"\u001b[33mYou are at: {CurrentLocation.Name}\u001b[0m");

        while (moving == false && moving_to != "Q")
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Which direction would you like to head in? \u001b[31mQ\u001b[0m to stay where you are.)");
            Console.WriteLine("\n\u001b[93m[N] North   [E] East\n" +
                              "[S] South   [W] West\u001b[0m " +
                              "\n\u001b[91m[Q] to stay here\u001b");
            Console.ResetColor();
            moving_to = Console.ReadLine().ToUpper();

            switch (moving_to)
            {
                case "N":
                    if (CurrentLocation.LocationToNorth == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your North.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(
                            $"You're planning to go North, towards {CurrentLocation.LocationToNorth.Name}. Are you sure?\n");
                        GUI.CWLine($"[Y] Go {CurrentLocation.LocationToNorth.Name}", ConsoleColor.Green);
                        GUI.CWLine($"[N] Stay at {CurrentLocation.Name}", ConsoleColor.Red);
                        Console.Write("\nChoice: ");
                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"You set off toward Town \u001b[93m{CurrentLocation.LocationToNorth.Name}\u001b[0m");
                            CurrentLocation = CurrentLocation.LocationToNorth;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer");
                        }
                    }

                    Console.WriteLine($"Your current location is: \u001b[93m{CurrentLocation.Name}\u001b[m");
                    break;

                case "E":
                    if (CurrentLocation.LocationToEast == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your East.");
                    }
                    else if (CurrentLocation.LocationToEast.Name == "Bridge" && CompletedQuests.Count < 2)
                    {
                        Console.WriteLine("You can not go east! Go complete some quests.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"You're planning to go East, towards {CurrentLocation.LocationToEast.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"You set off toward {CurrentLocation.LocationToEast.Name}\n");
                            CurrentLocation = CurrentLocation.LocationToEast;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer");
                        }
                    }

                    Console.WriteLine($"\nYou arrive at: {CurrentLocation.Name}");
                    break;

                case "S":
                    if (CurrentLocation.LocationToSouth == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your South.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"You're planning to go South, towards {CurrentLocation.LocationToSouth.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"You embark upon your path to {CurrentLocation.LocationToSouth.Name}");
                            CurrentLocation = CurrentLocation.LocationToSouth;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer");
                        }
                    }

                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;

                case "W":
                    if (CurrentLocation.LocationToWest == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your West.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"You're planning to go West, towards {CurrentLocation.LocationToWest.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"You embark upon your path to {CurrentLocation.LocationToWest.Name}");
                            CurrentLocation = CurrentLocation.LocationToWest;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer");
                        }
                    }

                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;

                case "Q":
                    Console.WriteLine("You've decided not to travel after all");
                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;
            }
        }
    }

    public void NameLisa()
    {
        List<string> Lisa = new List<string>
        {
            "Wow...",
            "Lisa...",
            "What a beautiful name.",
            "I'm in shock.",
            "I never heard such a beautiful name before.",
            "A name like that deserves something special.",
            "So here, take my secret weapon.",
            "I only give this to people with exceptionally good names...",
            "You abtained \u001b[33mThe legendary Lisa Abliterator\u001b[0m",
            "Use it wisely.",
            "Or not i don't really care."
        };

        foreach (string text in Lisa)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}