using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class ItemData
{
    public enum ItemType { Weapon , Armor , Consumable , Default };
    public string itemName;
    public long itemPrice;
    public string itemDescription;
    public Sprite itemImage;
}

