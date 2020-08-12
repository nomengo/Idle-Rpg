using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemContainer;
    public ItemDataList itemData;
   
    void Start()
    {
        foreach (var item in itemData.itemDatas)
        {
            GameObject itemInstance = (GameObject)Instantiate(itemPrefab);
            itemInstance.transform.SetParent(itemContainer.transform , false);
            itemInstance.transform.Find("ItemButton").GetComponent<Image>().sprite = item.itemImage;
            //Do other stuffs

            //
        }
    }
}
