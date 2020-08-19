using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestsEnter" , menuName = "QuestsEditor")]
public class QuestDataList : ScriptableObject
{
    public List<QuestData> quests = new List<QuestData>();
}
