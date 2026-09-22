using System;

namespace ConsoleApp4;

public class NPC
{
    public string Name;
    public Quest? QuestToGive;

    public NPC(string name, Quest? questToGive = null)
    {
        Name = name;
        QuestToGive = questToGive;
    }

    public static void PopulateNPCs()
    {
        NPC alchemist = new NPC("Alchemist", World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN));
        NPC farmer = new NPC("Farmer", World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD));
        NPC guard = new NPC("Guard");
        NPC villager = new NPC("Villager", World.QuestByID(World.QUEST_ID_COLLECT_SPIDER_SILK));

        PlaceNPC(World.LOCATION_ID_ALCHEMIST_HUT, alchemist);
        PlaceNPC(World.LOCATION_ID_FARMHOUSE, farmer);
        PlaceNPC(World.LOCATION_ID_GUARD_POST, guard);
        PlaceNPC(World.LOCATION_ID_BRIDGE, villager);
    }

    private static void PlaceNPC(int locationId, NPC npc)
    {
        Location? location = World.LocationByID(locationId);

        if (location == null)
        {
            throw new InvalidOperationException($"Location with ID {locationId} was not found.");
        }

        location.NPCHere = npc;

        if (npc.QuestToGive != null)
        {
            location.QuestAvailableHere = npc.QuestToGive;
        }
    }
}