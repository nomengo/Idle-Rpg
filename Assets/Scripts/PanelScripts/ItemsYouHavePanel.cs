using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemsYouHavePanel : MonoBehaviour
{
    private YourItemsList yourItems;
    private PanelTransitions panelTransitions;
    private Inventory inventory;

    public GameObject itemHolder;
    public GameObject allItemsContainer;

    [SerializeField] private GameObject inventoryInfoPlace;


    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        yourItems = FindObjectOfType<YourItemsList>();
        panelTransitions = FindObjectOfType<PanelTransitions>();
    }

    private void Start()
    {
        inventoryInfoPlace.SetActive(false);
    }

    public void ShowItem()
    {
        if (yourItems.Items.Count != 0)
        {
            foreach (var item in yourItems.Items)
            {
                GameObject itemObject = Instantiate(itemHolder);
                itemObject.transform.SetParent(allItemsContainer.transform, false);
                itemObject.transform.Find("ItemButton").GetComponent<Image>().sprite = item.itemImage;
                itemObject.transform.Find("ItemButton").GetComponent<Button>().onClick.AddListener(() => InventoryInfoCall(item));
            }
        }
        else
        {
            //As always do nothing
        }
    }

    public void DestroyItem()
    {
        if (allItemsContainer.transform.childCount != 0)
        {
            for (int i = 0; i < allItemsContainer.transform.childCount; i++)
            {
                Debug.Log("The Method Named DestroyItem Has Been Called!!");
                Destroy(allItemsContainer.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            //Do nothing
        }
    }

    private void InventoryInfoCall(ItemData itemdAtA)
    {
        inventoryInfoPlace.transform.position = new Vector3(inventoryInfoPlace.transform.position.x, -500, inventoryInfoPlace.transform.position.z);
        inventoryInfoPlace.SetActive(true);
        inventoryInfoPlace.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);

        inventoryInfoPlace.transform.Find("ItemTypeText").GetComponent<Text>().text = "Type: " + itemdAtA.itemType.ToString();
        inventoryInfoPlace.transform.Find("RemainingUpdateAmountText").GetComponent<Text>().text = "Upgrade Amount: " + itemdAtA.itemUpgradeAmount.ToString();
        inventoryInfoPlace.transform.Find("ItemDamageText").GetComponent<Text>().text = "Damage: " + itemdAtA.itemDamage.ToString();
        inventoryInfoPlace.transform.Find("ItemDefenseText").GetComponent<Text>().text = "Defense: " + itemdAtA.itemArmor.ToString();

        inventoryInfoPlace.transform.Find("ReturnButton").GetComponent<Button>().onClick.AddListener(() => inventoryInfoPlace.SetActive(false));

        inventoryInfoPlace.transform.Find("DiscardButton").GetComponent<Button>().onClick.RemoveAllListeners();
        inventoryInfoPlace.transform.Find("DiscardButton").GetComponent<Button>().onClick.AddListener(() => DiscardTheItem(itemdAtA));

        inventoryInfoPlace.transform.Find("EquipButton").GetComponent<Button>().onClick.RemoveAllListeners();
        inventoryInfoPlace.transform.Find("EquipButton").GetComponent<Button>().onClick.AddListener(() => EquipItem(itemdAtA));

        inventoryInfoPlace.transform.Find("UnequipButton").GetComponent<Button>().onClick.RemoveAllListeners();
        inventoryInfoPlace.transform.Find("UnequipButton").GetComponent<Button>().onClick.AddListener(() => UnequipItem(itemdAtA));
    }

    void EquipItem(ItemData itemData)
    {

        inventory.ItemPickUp(itemData);
    }


    void UnequipItem(ItemData itemData)
    {
        print(itemData.itemID);
        inventory.ItemGiveUp(itemData);
    }


    private void DiscardTheItem(ItemData itDat)
    {
        for (int i = 0; i < yourItems.Items.Count; i++)
        {
            if(yourItems.Items[i].itemID == itDat.itemID)
            {
                print("Item Has Been Discarded!!");
                yourItems.Items.RemoveAt(i);
                inventoryInfoPlace.SetActive(false);
                //
                DestroyItem();
                //
                ShowItem();
            }
            else
            {
                print("Nothing Discarded!!");
            }
        }
    }
}
