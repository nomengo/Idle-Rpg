using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    private GameObject ItemInfoPlace;

    private void Start()
    {
        ItemInfoPlace = gameObject.transform.GetChild(2).gameObject;
    }

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

    private void OnMouseOver()
    {
        ItemInfoPlace.SetActive(true);
    }

    private void OnMouseExit()
    {
        ItemInfoPlace.SetActive(false);
    }
}
