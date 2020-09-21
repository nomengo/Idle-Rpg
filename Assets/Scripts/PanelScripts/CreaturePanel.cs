using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreaturePanel : MonoBehaviour
{
    [SerializeField]private GameObject BattlePanel;

    [SerializeField] private BattlePanel battlePanel;

    private PanelTransitions panelTransitions;

    public GameObject creaturePrefab;
    public GameObject creatureContainer;
    public CreatureDataList Data;


    void Start()
    {
        panelTransitions = FindObjectOfType<PanelTransitions>();
        foreach (var item in Data.creatureList)
        {
            GameObject creatureInstance = (GameObject)Instantiate(creaturePrefab);
            creatureInstance.transform.SetParent(creatureContainer.transform, false);

            //creatureInstance.transform.GetComponent<Button>().onClick.AddListener(()=> { FindObjectOfType<BarManager>().GetExperience(item.howMuchExperienceDoesOneGonnaGet); });
            //creatureInstance.transform.GetComponent<Button>().onClick.AddListener(() => { FindObjectOfType<BarManager>().HealthDecrease(item.howMuchHealthNeededForOneTime); });
            //creatureInstance.transform.GetComponent<Button>().onClick.AddListener(() => { FindObjectOfType<BarManager>().EnergyDecrease(item.howMuchEnergyNeededForOneTime); });
            //creatureInstance.transform.GetComponent<Button>().onClick.AddListener(() => { FindObjectOfType<BarManager>().GiveMeTheMoney(item.rewardForCreature); });

            creatureInstance.transform.GetComponent<Button>().onClick.AddListener(() => {
                int id = ReturnID(item);
                battlePanel.ReceiveId(id);
            });
    
            creatureInstance.transform.GetComponent<Button>().onClick.AddListener(()=>panelTransitions.GoToBattlePanel());


            creatureInstance.transform.GetChild(0).GetComponent<Text>().text = "Exp: " + item.howMuchExperienceDoesOneGonnaGet.ToString();
            creatureInstance.transform.GetChild(1).GetComponent<Text>().text = "Gain: " + item.rewardForCreature.ToString("0");
            creatureInstance.transform.GetChild(2).GetComponent<Text>().text = "Level: " + item.creatureLevel.ToString("0");
            creatureInstance.transform.GetChild(3).GetComponent<Text>().text = item.creatureName.ToString();
        }
    }

    public int ReturnID(CreatureData creatureData)
    {
        return creatureData.CreatureID;
    }
}
