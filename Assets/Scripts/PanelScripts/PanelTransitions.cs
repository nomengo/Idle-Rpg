using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
    public GameObject AllItemsYouHavePan;
    public GameObject AllGamePanelsPan;

    public void GoToMainPanel()
    {
        AllItemsYouHavePan.SetActive(false);
        BattlePan.SetActive(false);
        ShopPan.SetActive(false);
        QuestPan.SetActive(false);
        AllGamePanelsPan.SetActive(true);
        DownGamePans.SetActive(true);
        MainUpPan.SetActive(true);
        GuildPan.SetActive(false);
        CreaturePan.SetActive(false);
        BlacksmithPan.SetActive(false);
        MainDownPan.transform.position = new Vector3(MainDownPan.transform.position.x, -500, MainDownPan.transform.position.z);
        MainDownPan.SetActive(true);
        MainDownPan.GetComponent<RectTransform>().DOAnchorPosY(0,.5f);
    }

    public void GoToQuestPanel()
    {
        GuildPan.SetActive(false);
        QuestPan.transform.position = new Vector3(QuestPan.transform.position.x, -500, QuestPan.transform.position.z);
        QuestPan.SetActive(true);
        QuestPan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }

    public void GoToHuntingPanel()
    {
        MainDownPan.SetActive(false);
        BattlePan.SetActive(false);
        CreaturePan.transform.position = new Vector3(CreaturePan.transform.position.x, -500, CreaturePan.transform.position.z);
        CreaturePan.SetActive(true);
        CreaturePan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }

    public void GoToShopPanel()
    {
        DownGamePans.SetActive(false);
        MainUpPan.SetActive(false);
        ShopPan.transform.position = new Vector3(ShopPan.transform.position.x, -500, ShopPan.transform.position.z);
        ShopPan.SetActive(true);
        ShopPan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }

    public void GoToGuildPanel()
    {
        MainDownPan.SetActive(false);
        GuildPan.transform.position = new Vector3(GuildPan.transform.position.x, -500, GuildPan.transform.position.z);
        GuildPan.SetActive(true);
        GuildPan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }

    public void GoToBlacksmithPanel()
    {
        MainDownPan.SetActive(false);
        BlacksmithPan.transform.position = new Vector3(BlacksmithPan.transform.position.x, -500, BlacksmithPan.transform.position.z);
        BlacksmithPan.SetActive(true);
        BlacksmithPan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }

    public void GoToBattlePanel()
    {
        CreaturePan.SetActive(false);
        BattlePan.transform.position = new Vector3(BattlePan.transform.position.x, -500, BattlePan.transform.position.z);
        BattlePan.SetActive(true);
        BattlePan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }

    public void GoToAllItemsPanel()
    {
        MainUpPan.SetActive(false);
        DownGamePans.SetActive(false);
        AllGamePanelsPan.SetActive(false);
        AllItemsYouHavePan.transform.position = new Vector3(AllItemsYouHavePan.transform.position.x, -500, AllItemsYouHavePan.transform.position.z);
        AllItemsYouHavePan.SetActive(true);
        AllItemsYouHavePan.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
    }
}
