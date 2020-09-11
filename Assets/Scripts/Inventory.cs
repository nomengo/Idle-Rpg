using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject weaponHolder;
    public GameObject armorHolder;
    public GameObject healthPotHolder;

    public float itemDamage;
    public float itemArmor;

   // public bool[] isFull;


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
            AllDatasToWeaponHolder(item);
            
        }
       else if(item.itemType == ItemType.Armor)
        {
            Debug.Log("ItemType : Armor");
            armorHolder.transform.GetChild(1).GetComponent<Image>().sprite = item.itemImage;
            AllDatasToArmorHolder(item);
        }
       else
        {
            Debug.Log("ItemType : Default");
        }
    }

    private void AllDatasToWeaponHolder(ItemData itemData)
    {
        weaponHolder.GetComponent<HolderData>().itemData.itemType = itemData.itemType;
        weaponHolder.GetComponent<HolderData>().itemData.itemName = itemData.itemName;
        weaponHolder.GetComponent<HolderData>().itemData.itemDamage = itemData.itemDamage;
        itemDamage = itemData.itemDamage;
    }

    private void AllDatasToArmorHolder(ItemData itemData)
    {
        armorHolder.GetComponent<HolderData>().itemData.itemType = itemData.itemType;
        armorHolder.GetComponent<HolderData>().itemData.itemName = itemData.itemName;
        armorHolder.GetComponent<HolderData>().itemData.itemArmor = itemData.itemArmor;
        itemArmor = itemData.itemArmor;
    }
}
