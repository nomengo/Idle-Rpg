using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject ItemInfoPlace;
    
    public void ShowInfo()
    {
        ItemInfoPlace.SetActive(true);
    }

    public void BuyItem()
    {
        //To do: buy the item


        //
        ItemInfoPlace.SetActive(false);
    }
}
