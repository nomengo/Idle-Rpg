using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Level;
    public int Money;

    public PlayerData(BarManager barManager)
    {
        Level = barManager.Level;
        Money = barManager.Money;
    }
}
