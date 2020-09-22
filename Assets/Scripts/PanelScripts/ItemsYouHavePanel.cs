using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsYouHavePanel : MonoBehaviour
{
    private YourItemsList yours;

    public GameObject itemHolder;
    public GameObject allItemsContainer;

    public List<ItemData> itemsYouHave = new List<ItemData>();

    private void Start()
    {
        yours = FindObjectOfType<YourItemsList>();
        foreach (var i in yours.Items)
        {
            itemsYouHave.Add(i);
        }

        foreach (var item in itemsYouHave)
        {
           GameObject ItemYouHave = Instantiate(itemHolder);
           ItemYouHave.transform.SetParent(allItemsContainer.transform, false);
        }
    }
}
