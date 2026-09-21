namespace ConsoleApp4;
public class Potion
{
    public int ID;
    public string Name;
    public string Effect;
    public int Damage;
    public int Gold_Value;

    public Potion(int potionID, string potionName, string potionEffect, int potionEffectValue, int potionGoldValue)
    {
        ID = potionID;
        Name = potionName;
        Effect = potionEffect;
        Damage = potionEffectValue;
        Gold_Value = potionGoldValue;
    }

    public void Potion_Self(Player player1)
    {
        if(Effect == "Health")
        {
            Console.WriteLine("As you drink the potion you feel your pain fade away.");
            player1.Heal(Value);
            Console.WriteLine($"Health += {Value}");
            Console.WriteLine($"Your current health is: {player1.health.Currenthitpoints} / {player1.health.Maximumhitpoints}");
        }
        if(Effect == "Strength")
        {
            Console.WriteLine("As you drink the potion you feel yourself get stronger.");
            player1.CurrentWeapon.Damage += Value;
            Console.WriteLine($"Every attack now does {Value} more damage");
            Console.WriteLine($"Every hit you perform now does {player1.CurrentWeapon.Damage} damage.");
        }
    }

    public void Potion_Enemy(Monster monster)
    {
        if(Effect == "Poison")
        {
            if(monster.Name == "Spider")
            {
                Console.WriteLine($"As the flask hits the {monster.Name} square on it... blinks?");
                Console.WriteLine($"The {monster.Name} only took 1 damage");
                monster.health.TakeDamage(1);
            }
            else
            {
                Console.WriteLine($"As the flask hits the {monster.Name} it lets out a shriek");
                Console.WriteLine($"As the poison coats the {monster.Name}'s body you can see it get weaker");
                Console.WriteLine($"The {monster.Name} now takes {Value} damage per turn and deals 1 less damage to you!");
                monster.health.TakeDamage(Value);
                monster.MaximumDamage -= 1;
            }
        }

    }
}