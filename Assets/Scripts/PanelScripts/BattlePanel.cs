using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : MonoBehaviour
{
    [SerializeField] private CreatureDataList creatureDataList;

    [SerializeField] private Text creatureHealth;
    [SerializeField] private Text creatureArmor;
    [SerializeField] private Text takenEnergy;
    [SerializeField] private Text takenHealth;
    [SerializeField] private Text description;

    private Inventory inventory;

    private bool isTheBattleCompleted;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void ReceiveId(int id)
    {
        foreach (var creature in creatureDataList.creatureList)
        {
            if(creature.CreatureID == id)
            {
                creatureHealth.text = "Health:" + creature.creatureHealth.ToString();
                creatureArmor.text = "Armor:" + creature.creatureArmor.ToString();
                takenEnergy.text = "Energy Needed:" + creature.howMuchEnergyNeededForOneTime.ToString();
                takenHealth.text = "Health Needed:" + creature.howMuchHealthNeededForOneTime.ToString();
                description.text = creature.creatureDescription;
            }
        }
    }

    public void Battle()
    {
        if (!isTheBattleCompleted)
        {

            StartCoroutine(BattleCo());
        }
    }

    public IEnumerator BattleCo()
    {
        while (true)
        {
            //if(inventory)

            yield return null;
        }
    }
}
