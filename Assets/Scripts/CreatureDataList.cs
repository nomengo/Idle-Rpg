using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureDataEnter" , menuName = "CreatureDataEditor")]
public class CreatureDataList  : ScriptableObject
{
    //This list is contains creature data 
    public List<CreatureData> creatureList = new List<CreatureData>();
}
