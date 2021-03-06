﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopPanel : MonoBehaviour
{
    private Inventory inventory;
    private BarManager barManager;
    private YourItemsList yourItemsList;

    public GameObject itemPrefab;
    public GameObject itemContainer;
    public GameObject itemDamagePlace;
    public GameObject itemArmorPlace;

    [SerializeField] private ItemDataList itemData;

    [SerializeField] private GameObject itemInfoPan;
    [SerializeField] private GameObject infoManagement;
    private void Awake()
    {
        yourItemsList = FindObjectOfType<YourItemsList>();
        inventory = FindObjectOfType<Inventory>();
        barManager = FindObjectOfType<BarManager>();
    }

    void Start()
    {
        foreach (var item in itemData.itemDatas)
        {
            GameObject itemInstance = (GameObject)Instantiate(itemPrefab);
            itemInstance.transform.SetParent(itemContainer.transform, false);
            itemInstance.transform.Find("ItemButton").GetComponent<Image>().sprite = item.itemImage;
            itemInstance.transform.Find("ItemButton").GetComponent<Button>().onClick.AddListener(() => ItemInfoCall(item));
        }
    }

    private void ItemInfoCall(ItemData obj)
    {
        itemInfoPan.transform.position = new Vector3(itemInfoPan.transform.position.x, -500, itemInfoPan.transform.position.z);
        itemInfoPan.SetActive(true);
        itemInfoPan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(0).Find("NameText").GetComponent<Text>().text = obj.itemName.ToString();
        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(1).Find("PriceText").GetComponent<Text>().text = obj.itemPrice.ToString("0");
        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(2).Find("DescriptionText").GetComponent<Text>().text = obj.itemDescription.ToString();
        if(obj.itemType == ItemType.Weapon)
        {
            itemDamagePlace.SetActive(true);
            itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(3).Find("ItemDamageText").GetComponent<Text>().text = "Damage: " + obj.itemDamage.ToString();
        }
        else if(obj.itemType == ItemType.Armor)
        {
            itemArmorPlace.SetActive(true);
            itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(4).Find("ItemArmorText").GetComponent<Text>().text = "Armor: " + obj.itemArmor.ToString();
        }

        
        //Editörden buton'a bir şey ekleyeceksen dikkat et o listenerıda runtimeda siler
        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Button>().onClick.RemoveAllListeners();
        //
        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Button>().onClick.AddListener(() => BuyItem(obj));

        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Button>().onClick.RemoveAllListeners();

        itemInfoPan.transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Button>().onClick.AddListener(BackToShop);
    }

    private void BackToShop()
    {
        itemDamagePlace.SetActive(false);
        itemArmorPlace.SetActive(false);
        itemInfoPan.SetActive(false);
        
    }

    public void BuyItem(ItemData itemData)
    {
        if(barManager.Money >= itemData.itemPrice)
        {
            infoManagement.GetComponent<InfoManagement>().Info("You Bought The Item!!", 1f);
            yourItemsList.Items.Add(itemData);
            barManager.TakeMyMoney(itemData.itemPrice);
            //inventory.ItemPickUp(itemData);
            itemDamagePlace.SetActive(false);
            itemArmorPlace.SetActive(false);
            itemInfoPan.SetActive(false);
        }
        else
        {
            infoManagement.GetComponent<InfoManagement>().Info("Not Enough Money!!", 1f);
        }
    }
}
