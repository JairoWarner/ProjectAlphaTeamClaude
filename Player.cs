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

    public bool MoveLocations()
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

            Console.WriteLine("\nWhere would you like to go?");

            Console.WriteLine(
                "\n\u001b[93m[N] North   [E] East\n" +
                "[S] South   [W] West\u001b[0m" +
                "\n\u001b[91m[Q] Stay here\u001b[0m"
            );

            Console.ResetColor();

            Console.Write("\nChoice: ");

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

                        Console.WriteLine($"You're planning to go North, towards {CurrentLocation.LocationToNorth.Name}. Are you sure?\n");
                        GUI.CWLine($"[Y] Go to {CurrentLocation.LocationToNorth.Name}", ConsoleColor.Green);
                        GUI.CWLine($"[N] Stay at {CurrentLocation.Name}", ConsoleColor.Red);

                        Console.Write("\nChoice: ");
                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"\nYou embark upon your path to {CurrentLocation.LocationToNorth.Name}.");

                            CurrentLocation = CurrentLocation.LocationToNorth;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer.");
                            GUI.PressEnter();
                        }
                    }

                    break;


                case "E":
                    if (CurrentLocation.LocationToEast == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your East.");
                    }
                    else if (
                        CurrentLocation.LocationToEast.Name == "Bridge" &&
                        CompletedQuests.Count < 2
                    )
                    {
                        Console.WriteLine("You cannot go East yet! Complete some quests first.");
                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine($"You're planning to go East, towards {CurrentLocation.LocationToEast.Name}. Are you sure?\n");
                        GUI.CWLine($"[Y] Go to {CurrentLocation.LocationToEast.Name}", ConsoleColor.Green);
                        GUI.CWLine($"[N] Stay at {CurrentLocation.Name}", ConsoleColor.Red);
                        Console.Write("\nChoice: ");

                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"\nYou embark upon your path to {CurrentLocation.LocationToEast.Name}.");

                            CurrentLocation = CurrentLocation.LocationToEast;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer.");
                        }
                    }

                    break;


                case "S":
                    if (CurrentLocation.LocationToSouth == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your South.");
                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine($"You're planning to go South, towards {CurrentLocation.LocationToSouth.Name}. Are you sure?\n");
                        GUI.CWLine($"[Y] Go to {CurrentLocation.LocationToSouth.Name}", ConsoleColor.Green);
                        GUI.CWLine($"[N] Stay at {CurrentLocation.Name}", ConsoleColor.Red);

                        Console.Write("\nChoice: ");

                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"\nYou embark upon your path to {CurrentLocation.LocationToSouth.Name}.");

                            CurrentLocation = CurrentLocation.LocationToSouth;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer.");
                        }
                    }

                    break;


                case "W":
                    if (CurrentLocation.LocationToWest == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your West.");
                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine($"You're planning to go West, towards {CurrentLocation.LocationToWest.Name}. Are you sure?\n");

                        GUI.CWLine($"[Y] Go to {CurrentLocation.LocationToWest.Name}", ConsoleColor.Green);

                        GUI.CWLine($"[N] Stay at {CurrentLocation.Name}", ConsoleColor.Red);

                        Console.Write("\nChoice: ");

                        confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            Console.WriteLine($"\nYou embark upon your path to {CurrentLocation.LocationToWest.Name}.");

                            CurrentLocation = CurrentLocation.LocationToWest;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine("You have decided to stick around for a little while longer.");
                        }
                    }
                    break;

                case "Q":
                    Console.WriteLine("\nYou've decided not to travel after all.");
                    return false;

                default:
                    Console.WriteLine("Please choose N, E, S, W or Q.");
                    break;
            }
        }

        return true;
    }
}