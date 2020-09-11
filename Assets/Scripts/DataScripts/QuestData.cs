using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum QuestType
{
    Kill , 
    Collecting 
}

[Serializable]
public class QuestData 
{
    public QuestType questType;

    public bool isActive;
    public bool isDone;

    public string questTitle;
    public string questDescription;

    public int money;
    public int experience;
    public int questID;
    public int requiredCreatureID;
}
