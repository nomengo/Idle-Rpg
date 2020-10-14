using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureDataEnter" , menuName = "CreatureDataEditor" , order = 1)]
public class CreatureDataList  : ScriptableObject
{
    //This list contains creature data 
    public List<CreatureData> creatureList = new List<CreatureData>();
}
