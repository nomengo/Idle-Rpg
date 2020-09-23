using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal : MonoBehaviour
{
    public QuestData quest;

    private CreatureData _creatureData;
    
    public void QuestProgress(int cID)
    {
        if (quest.requiredCreatureID == cID)
        {
            quest.isDone = true;
        }
    }
}
