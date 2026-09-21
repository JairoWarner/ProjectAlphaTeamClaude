namespace ConsoleApp4;

public class Player
{
    public string Name;
    public Health health;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public List<Quest> ActiveQuests = new([]);
    public List<Quest> CompletedQuests = new([]);

    public Player(string name, int currenthitpoints, int maximumhitpoints)
    {
        Name = name;
        health = new Health(currenthitpoints, maximumhitpoints);
        CurrentWeapon = null;
        CurrentLocation = null;
    }

    public bool IfAlive()
    {
        return health.IsAlive();
    }

    public void Heal(int amount)
    {
        health.Heal(amount);
    }
    public int CalculateDamage()
    {
        return World.RandomGenerator.Next(0, CurrentWeapon.Damage + 1);
    }

    public void MoveLocations()
    {

        bool moving = false;
        string moving_to = "";
        string confirmation = "";
        CurrentLocation.ShowMap();
        Console.WriteLine($"You are currently at {CurrentLocation.Name}");
        while(moving == false && moving_to != "Q")
        {
            Console.WriteLine("Which direction would you like to head in? (N/E/S/W) (Q to stay where you are.)");
            moving_to = Console.ReadLine().ToUpper();
            switch (moving_to)
            {
                case "N":
                    if(CurrentLocation.LocationToNorth == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your North.");
                    }
                    else
                    {
                        Console.WriteLine($"You're planning to go North, towards {CurrentLocation.LocationToNorth.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();
                        if(confirmation == "Y")
                        {
                            Console.WriteLine($"You embark upon your path to {CurrentLocation.LocationToNorth.Name}");
                            CurrentLocation = CurrentLocation.LocationToNorth;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine($"You have decided to stick around for a little while longer");
                        }
                    }
                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;

                case "E":
                    if(CurrentLocation.LocationToEast == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your East.");
                    }
                    else if (CurrentLocation.LocationToEast.Name == "Bridge" && CompletedQuests.Count < 2)
                    {
                        Console.WriteLine("You can not go east! Go complete some quests.");
                    }
                    else
                    {
                        Console.WriteLine($"You're planning to go East, towards {CurrentLocation.LocationToEast.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();
                        if(confirmation == "Y")
                        {
                            Console.WriteLine($"You embark upon your path to {CurrentLocation.LocationToEast.Name}");
                            CurrentLocation = CurrentLocation.LocationToEast;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine($"You have decided to stick around for a little while longer");
                        }
                    }
                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;
                case "S":
                    if(CurrentLocation.LocationToSouth == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your South.");
                    }
                    else
                    {
                        Console.WriteLine($"You're planning to go South, towards {CurrentLocation.LocationToSouth.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();
                        if(confirmation == "Y")
                        {
                            Console.WriteLine($"You embark upon your path to {CurrentLocation.LocationToSouth.Name}");
                            CurrentLocation = CurrentLocation.LocationToSouth;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine($"You have decided to stick around for a little while longer");
                        }
                    }
                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;

                case "W":
                    if(CurrentLocation.LocationToWest == null)
                    {
                        Console.WriteLine("Unfortunately there is no location to your West.");
                    }
                    else
                    {
                        Console.WriteLine($"You're planning to go West, towards {CurrentLocation.LocationToWest.Name}. Are you sure? (Y/N)");
                        confirmation = Console.ReadLine().ToUpper();
                        if(confirmation == "Y")
                        {
                            Console.WriteLine($"You embark upon your path to {CurrentLocation.LocationToWest.Name}");
                            CurrentLocation = CurrentLocation.LocationToWest;
                            moving = true;
                        }
                        else
                        {
                            Console.WriteLine($"You have decided to stick around for a little while longer");
                        }
                    }
                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;

                case "Q":
                    Console.WriteLine($"You've decided not to travel after all");
                    Console.WriteLine($"Your current location is: {CurrentLocation.Name}");
                    break;

            }
        }
    }

}