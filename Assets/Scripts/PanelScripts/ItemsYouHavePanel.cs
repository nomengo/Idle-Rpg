using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsYouHavePanel : MonoBehaviour
{
    private YourItemsList yourItems;

    public GameObject itemHolder;
    public GameObject allItemsContainer;

    private void Awake()
    {
        yourItems = FindObjectOfType<YourItemsList>();
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
                Debug.Log("It got destroyed!!");
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
        //print(itemdAtA.itemDescription);
    }

}
