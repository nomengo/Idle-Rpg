using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject weaponHolder;
    public GameObject armorHolder;
    public GameObject healthPotHolder;

    public bool[] isFull;


    public void ItemPickUp(ItemData item)
    {
       if(item.itemType == ItemType.Consumable)
        {
            Debug.Log("ItemType : Consumable");
            healthPotHolder.transform.GetChild(1).GetComponent<Image>().sprite = item.itemImage;
        }
       else if(item.itemType == ItemType.Weapon)
        {
            Debug.Log("ItemType : Weapon");
            weaponHolder.transform.GetChild(1).GetComponent<Image>().sprite = item.itemImage;
        }
       else if(item.itemType == ItemType.Armor)
        {
            Debug.Log("ItemType : Armor");
            armorHolder.transform.GetChild(1).GetComponent<Image>().sprite = item.itemImage;
        }
       else
        {
            Debug.Log("ItemType : Default");
        }
    }
}
