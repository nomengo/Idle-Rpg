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
    [SerializeField] private Text BattleText;

    private float MonsterHealth;
    private float MonsterArmor;
    private float MonsterDamage;
    private float RequiredEnergyForKilling;

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
                MonsterHealth = creature.creatureHealth;

                creatureArmor.text = "Armor:" + creature.creatureArmor.ToString();
                MonsterArmor = creature.creatureArmor;

                takenEnergy.text = "Energy Needed:" + creature.howMuchEnergyNeededForOneTime.ToString();
                RequiredEnergyForKilling = creature.howMuchEnergyNeededForOneTime;

                takenHealth.text = "Health Needed:" + creature.howMuchHealthNeededForOneTime.ToString();
                MonsterDamage = creature.howMuchHealthNeededForOneTime;

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
            if(inventory.itemDamage > 0 && inventory.itemArmor > 0)
            {
                MonsterHealth = (MonsterHealth + MonsterArmor) - inventory.itemDamage;
                //Debug.Log(MonsterHealth);
                BattleText.text = MonsterHealth.ToString("0");
                yield return new WaitForSeconds(1f);
            }
            else
            {
                BattleText.text = "You Need Both Weapon And Armor!!!";
                yield return new WaitForSeconds(2f);
                BattleText.text = "";
                break;
            }
            yield return null;
        }
    }
}
