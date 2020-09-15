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
        StartCoroutine(GetReadyCo());
    }

    private IEnumerator GetReadyCo()
    {
        GetReady();
        yield return new WaitForSeconds(1f);
    }

    private void GetReady() 
    {
        if (_inventory.itemDamage != 0 && _inventory.itemArmor != 0)
        {
            WeaponUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.weaponHolder.GetComponent<HolderData>().itemData.itemImage;
            UpgradeWeapon(_inventory.weaponHolder.GetComponent<HolderData>().itemData);

            ArmorUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.armorHolder.GetComponent<HolderData>().itemData.itemImage;
            UpgradeArmor(_inventory.armorHolder.GetComponent<HolderData>().itemData);
        }
        else if (_inventory.itemArmor != 0)
        {
            ArmorUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.armorHolder.GetComponent<HolderData>().itemData.itemImage;
            UpgradeArmor(_inventory.armorHolder.GetComponent<HolderData>().itemData);
            WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A WEAPON!";
        }
        else if (_inventory.itemDamage != 0)
        {
            WeaponUpgrade.transform.GetChild(4).GetComponent<Image>().sprite = _inventory.weaponHolder.GetComponent<HolderData>().itemData.itemImage;
            UpgradeWeapon(_inventory.weaponHolder.GetComponent<HolderData>().itemData);
            WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A ARMOR!";

        }
        else
        {
            WeaponUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A ARMOR!";
            ArmorUpgrade.transform.GetChild(1).GetComponent<Text>().text = "YOU DON'T HAVE A WEAPON";
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
        if(PlayerData.money >= gItem.itemPrice) 
        {
            _inventory.itemDamage += 1f;
            PlayerData.money -= gItem.itemPrice;
            Debug.Log(PlayerData.money);
            Debug.Log("You Upgraded Your Weapon!!!");
        }
    }

    private void ArmorUpgradeTime(ItemData gItem)
    {
        if (PlayerData.money >= gItem.itemPrice)//Check if money is decreasing or not
        {
            _inventory.itemArmor += 1f;
            PlayerData.money -= gItem.itemPrice;
            Debug.Log(PlayerData.money);
            Debug.Log("You Upgraded Your Armor!!!");
        }
    }
}
