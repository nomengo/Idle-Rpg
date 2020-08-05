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

    public void GoToMainPanel()
    {
        ShopPan.SetActive(false);
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
        MainDownPan.SetActive(false);
        ShopPan.SetActive(true);
    }
}
