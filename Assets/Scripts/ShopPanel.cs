using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemContainer;
    public ItemDataList itemData;
    [SerializeField] private GameObject itemInfoPan;

    void Start()
    {
        foreach (var item in itemData.itemDatas)
        {
            GameObject itemInstance = (GameObject)Instantiate(itemPrefab);
            itemInstance.transform.SetParent(itemContainer.transform, false);
            itemInstance.transform.Find("ItemButton").GetComponent<Image>().sprite = item.itemImage;
            itemInstance.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => ItemInfoCall(item));
        }

    }

    private void ItemInfoCall(ItemData obj)
    {
        itemInfoPan.SetActive(true);
        itemInfoPan.transform.GetChild(0).Find("NameText").GetComponent<Text>().text = obj.itemName.ToString();
        itemInfoPan.transform.GetChild(1).Find("PriceText").GetComponent<Text>().text = obj.itemPrice.ToString("0");
        itemInfoPan.transform.GetChild(2).Find("DescriptionText").GetComponent<Text>().text = obj.itemDescription.ToString();
        //Do some other stuff with BUY button here
        
        //
        itemInfoPan.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(BackToShop);
    }

    private void BackToShop()
    {
        itemInfoPan.SetActive(false);
    }
}
