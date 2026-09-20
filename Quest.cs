public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public int RequiredKills;
    public int TargetMonsterID;
    public int CurrentKills;
    private bool iscompleted;

    public Quest(int id, string name, string description, int requiredKills, int targetMonsterID)
    {
        ID = id;
        Name = name;
        Description = description;
        RequiredKills = requiredKills;
        TargetMonsterID = targetMonsterID;
        CurrentKills = 0;
        iscompleted = false;
    }

    public void RegisterKill()
    {
        CurrentKills++;
        if (CurrentKills >= RequiredKills)
        {
            iscompleted = true;
        }
    }

    public bool IsCompleted()
    {
        return iscompleted;
    }
}