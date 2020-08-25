using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemDataEnter" , menuName = "Inventory/ItemDataEditor" , order = 2)]
public class ItemDataList : ScriptableObject
{
      public List<ItemData> itemDatas = new List<ItemData>();
}
