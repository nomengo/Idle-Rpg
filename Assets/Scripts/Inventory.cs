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

    public int weaponUpgradeAmount;
    public int armorUpgradeAmount;


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

    public void ItemGiveUp(ItemData item)
    {
        if(item.itemType == ItemType.Weapon)
        {
            if (itemDamage != 0)
            {
                weaponHolder.GetComponent<HolderData>().itemData.itemType = ItemType.Default;
                weaponHolder.GetComponent<HolderData>().itemData.itemName = "";
                weaponHolder.GetComponent<HolderData>().itemData.itemDamage = 0f;
                weaponHolder.GetComponent<HolderData>().itemData.itemImage = null;
                weaponHolder.transform.GetChild(1).GetComponent<Image>().sprite = null;
                itemDamage = 0f;
                weaponUpgradeAmount = 0;
            }
            else
            {

            }
        }
        else if(item.itemType == ItemType.Armor)
        {
            if (itemArmor != 0)
            {
                armorHolder.GetComponent<HolderData>().itemData.itemType = ItemType.Default;
                armorHolder.GetComponent<HolderData>().itemData.itemName = "";
                armorHolder.GetComponent<HolderData>().itemData.itemArmor = 0f;
                armorHolder.GetComponent<HolderData>().itemData.itemImage = null;
                armorHolder.transform.GetChild(1).GetComponent<Image>().sprite = null;
                itemArmor = 0f;
                armorUpgradeAmount = 0;
            }
            else
            {

            }
        }
    }



    private void AllDatasToWeaponHolder(ItemData itemData)
    {
        weaponHolder.GetComponent<HolderData>().itemData.itemType = itemData.itemType;
        weaponHolder.GetComponent<HolderData>().itemData.itemName = itemData.itemName;
        weaponHolder.GetComponent<HolderData>().itemData.itemDamage = itemData.itemDamage;
        weaponHolder.GetComponent<HolderData>().itemData.itemImage = itemData.itemImage;
        //PlayerData.itemDam = itemData.itemDamage;
        itemDamage = itemData.itemDamage;
        weaponUpgradeAmount = itemData.itemUpgradeAmount;
    }

    private void AllDatasToArmorHolder(ItemData itemData)
    {
        armorHolder.GetComponent<HolderData>().itemData.itemType = itemData.itemType;
        armorHolder.GetComponent<HolderData>().itemData.itemName = itemData.itemName;
        armorHolder.GetComponent<HolderData>().itemData.itemArmor = itemData.itemArmor;
        armorHolder.GetComponent<HolderData>().itemData.itemImage = itemData.itemImage;
        //PlayerData.itemArm = itemData.itemArmor;
        itemArmor = itemData.itemArmor;
        armorUpgradeAmount = itemData.itemUpgradeAmount;
    }

}
