using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum ItemType { Weapon, Armor, Consumable, Default };


[Serializable]
public class ItemData
{
    public ItemType itemType = ItemType.Default;
    public string itemName;
    public int itemPrice;
    public string itemDescription;
    public Sprite itemImage;
}

