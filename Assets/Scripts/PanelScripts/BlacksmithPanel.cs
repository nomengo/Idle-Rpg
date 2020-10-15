using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlacksmithPanel : MonoBehaviour
{
    [SerializeField] private GameObject WeaponUpgrade;
    [SerializeField] private GameObject ArmorUpgrade;

    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        GetReady();
    }

    private void GetReady() 
    {
        if (_inventory.itemDamage != 0 && _inventory.itemArmor != 0)
        {
           WeaponUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.weaponHolder.GetComponent<HolderData>().itemData.itemImage;
           WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU CAN UPGRADE THIS ITEM " + _inventory.weaponUpgradeAmount + " POINTS";
           UpgradeWeapon(_inventory.weaponHolder.GetComponent<HolderData>().itemData);

           ArmorUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.armorHolder.GetComponent<HolderData>().itemData.itemImage;
           ArmorUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU CAN UPGRADE THIS ITEM " + _inventory.armorUpgradeAmount + " POINTS";
           UpgradeArmor(_inventory.armorHolder.GetComponent<HolderData>().itemData);
        }
        else if (_inventory.itemArmor != 0)
        {
           ArmorUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.armorHolder.GetComponent<HolderData>().itemData.itemImage;
           UpgradeArmor(_inventory.armorHolder.GetComponent<HolderData>().itemData);
           ArmorUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU CAN UPGRADE THIS ITEM " + _inventory.armorUpgradeAmount + " POINTS";
           WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A WEAPON!";
        }
        else if (_inventory.itemDamage != 0)
        {
           WeaponUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.weaponHolder.GetComponent<HolderData>().itemData.itemImage;
           UpgradeWeapon(_inventory.weaponHolder.GetComponent<HolderData>().itemData);
           WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU CAN UPGRADE THIS ITEM " + _inventory.weaponUpgradeAmount + " POINTS";
           ArmorUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A ARMOR!";
        }
        else
        {
           WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A WEAPON!";
           ArmorUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A ARMOR";
        }
    }

    private void UpgradeWeapon(ItemData itemD)
    {
        WeaponUpgrade.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => WeaponUpgradeTime(itemD));
    }

    private void UpgradeArmor(ItemData itemD)
    {
        ArmorUpgrade.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => ArmorUpgradeTime(itemD));
    }

    private void WeaponUpgradeTime(ItemData gItem)//Check if money is decreasing or not
    {
        if (_inventory.weaponUpgradeAmount != 0)
        {
            _inventory.itemDamage += 1f;
            //PlayerData.money -= gItem.itemPrice;
            Debug.Log("You Upgraded Your Weapon!!!");
            _inventory.weaponUpgradeAmount -= 1;
        }
        else
        {
            //Do something 
            WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU CAN'T UPGRADE THIS ITEM ANYMORE";
        }
    }

    private void ArmorUpgradeTime(ItemData gItem)
    {
        if(_inventory.armorUpgradeAmount != 0)
        {
            _inventory.itemArmor += 1f;
            //PlayerData.money -= gItem.itemPrice;
            Debug.Log("You Upgraded Your Armor!!!");
            _inventory.armorUpgradeAmount -= 1;
        }
        else
        {
            //Do something 
            ArmorUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU CAN'T UPGRADE THIS ITEM ANTMORE";
        }
    }
}
