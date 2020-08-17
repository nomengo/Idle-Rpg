using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum ItemType { Weapon, Armor, Consumable, Default };


[Serializable]
public class ItemData
{
    public ItemType itemType;
    public string itemName;
    public long itemPrice;
    public string itemDescription;
    public Sprite itemImage;
}

