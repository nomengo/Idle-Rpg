using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTransitions : MonoBehaviour
{
    [Header("PanelGameObject")]
    public GameObject MainDownPan;
    public GameObject GuildPan;
    public GameObject CreaturePan;
    public GameObject ShopPan;
    public GameObject DownGamePans;
    public GameObject MainUpPan;
    public GameObject QuestPan;
    public GameObject BattlePan;
    public GameObject BlacksmithPan;

    public void GoToMainPanel()
    {
        BattlePan.SetActive(false);
        ShopPan.SetActive(false);
        QuestPan.SetActive(false);
        DownGamePans.SetActive(true);
        MainUpPan.SetActive(true);
        GuildPan.SetActive(false);
        CreaturePan.SetActive(false);
        BlacksmithPan.SetActive(false);
        MainDownPan.SetActive(true);
        
    }

    public void GoToQuestPanel()
    {
        GuildPan.SetActive(false);
        QuestPan.SetActive(true);
    }

    public void GoToHuntingPanel()
    {
        MainDownPan.SetActive(false);
        BattlePan.SetActive(false);
        CreaturePan.SetActive(true);
    }

    public void GoToShopPanel()
    {
        DownGamePans.SetActive(false);
        MainUpPan.SetActive(false);
        ShopPan.SetActive(true);
    }

    public void GoToGuildPanel()
    {
        MainDownPan.SetActive(false);
        GuildPan.SetActive(true);
    }

    public void GoToBlacksmithPanel()
    {
        MainDownPan.SetActive(false);
        BlacksmithPan.SetActive(true);
    }
}
