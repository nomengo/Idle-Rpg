using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTransitions : MonoBehaviour
{
    [Header("PanelGameObject")]
    public GameObject MainDownPan;
    public GameObject QuestPan;
    public GameObject CreaturePan;
    public GameObject ShopPan;
    public GameObject DownGamePans;
    public GameObject MainUpPan;

    public void GoToMainPanel()
    {
        ShopPan.SetActive(false);
        DownGamePans.SetActive(true);
        MainUpPan.SetActive(true);
        QuestPan.SetActive(false);
        CreaturePan.SetActive(false);
        MainDownPan.SetActive(true);
        
    }

    public void GoToQuestPanel()
    {
        MainDownPan.SetActive(false);
        QuestPan.SetActive(true);
    }

    public void GoToHuntingPanel()
    {
        MainDownPan.SetActive(false);
        CreaturePan.SetActive(true);
    }

    public void GoToShopPanel()
    {
        DownGamePans.SetActive(false);
        MainUpPan.SetActive(false);
        ShopPan.SetActive(true);
    }
}
