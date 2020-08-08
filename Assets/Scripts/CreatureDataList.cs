using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CreatureDataList  : ScriptableObject
{
    //This list is containing creaturedata everytime
    public List<CreatureData> creatureList = new List<CreatureData>();
}
