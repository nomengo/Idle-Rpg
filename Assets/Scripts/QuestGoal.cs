using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal : MonoBehaviour
{
    public QuestData quest;

    private CreatureData _creatureData;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log(quest.questDescription);

        }
    }
    
    public void QuestProgress(int cID)
    {
        if (quest.requiredCreatureID == cID)
        {
            quest.isDone = true;
        }
    }
}
