using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaturePanel : MonoBehaviour
{
    [SerializeField]private GameObject BattlePanel;

    public GameObject creaturePrefab;
    public GameObject creatureContainer;
    public CreatureDataList Data;

    [SerializeField] private BattlePanel battlePanel;

    void Start()
    {
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
            creatureInstance.transform.GetComponent<Button>().onClick.AddListener(()=> BattlePanel.SetActive(true));

            creatureInstance.transform.GetChild(0).GetComponent<Text>().text = item.howMuchExperienceDoesOneGonnaGet.ToString();
            creatureInstance.transform.GetChild(1).GetComponent<Text>().text = item.rewardForCreature.ToString("0");
            creatureInstance.transform.GetChild(2).GetComponent<Text>().text = "Level: " + item.creatureLevel.ToString("0");
            creatureInstance.transform.GetChild(3).GetComponent<Text>().text = item.creatureName.ToString();
        }
    }

    public int ReturnID(CreatureData creatureData)
    {
        return creatureData.CreatureID;
    }
}
