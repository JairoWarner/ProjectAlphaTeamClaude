using ConsoleApp4;
public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public int RequiredKills;
    public int TargetMonsterID;
    public int CurrentKills;
    private bool iscompleted;
    public int RewardItemID;
    public int RewardCoins;
    private bool rewardGiven = false;


    public Quest(int id, string name, string description, int requiredKills, int targetMonsterID, int rewardItemID)
    {
        ID = id;
        Name = name;
        Description = description;
        RequiredKills = requiredKills;
        TargetMonsterID = targetMonsterID;
        CurrentKills = 0;
        iscompleted = false;
        RewardItemID = rewardItemID;
    }

    public void RegisterKill()
    {
        CurrentKills++;
        if (CurrentKills >= RequiredKills)
        {
            iscompleted = true;
            GiveReward();
        }
    }

    public bool IsCompleted()
    {
        return iscompleted;
    }


    public void GiveReward()
    {
        if (iscompleted && !rewardGiven)
        {
            if (RewardItemID != 0)
            {
                Item reward = World.ItemByID(RewardItemID);
                Inventory.AddItemsToInventory(
                reward.Name,
                reward.ID,
                reward.Description,
                reward.Equipped,
                reward.Type,
                reward.ForBattle,
                1,
                reward.IsStackable,
                reward.Damage
                );
                Console.WriteLine($"You received: {reward.Name}");
            }
            //if (RewardCoins > 0)
            //{
                //Inventory.Coins += RewardCoins;
                //Console.WriteLine($"You received {RewardCoins} coins!");
            //}
            rewardGiven = true;
        }
        }
    }