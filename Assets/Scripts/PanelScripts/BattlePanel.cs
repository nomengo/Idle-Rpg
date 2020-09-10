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
    private float Experience;

    public float waitTime;

    private Inventory inventory;
    private BarManager _barManager;

    private bool isTheBattleCompleted;

    private int Reward;

    private void Start()
    {
        waitTime = 1f;
        _barManager = FindObjectOfType<BarManager>();
        inventory = FindObjectOfType<Inventory>();
    }

    public void ReceiveId(int id)
    {
        foreach (var creature in creatureDataList.creatureList)
        {
            if(creature.CreatureID == id)
            {

                Reward = creature.rewardForCreature;
                Experience = creature.howMuchExperienceDoesOneGonnaGet;

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
                for (int i = 1; i < 9999; i++)
                {
                    if(MonsterHealth > 0 && _barManager.healthBar.GetComponent<Image>().fillAmount > 0)
                    {
                        //Her iki tarafında canı varken
                        if (i % 2 == 0)
                        {
                            float gDamage =   MonsterArmor - inventory.itemDamage;
                            if(gDamage < 0)
                            {
                                gDamage = -gDamage;
                                MonsterHealth = MonsterHealth - gDamage;
                            }
                            else
                            {
                                MonsterHealth = MonsterHealth - gDamage;
                            }
                            //Debug.Log(MonsterHealth);
                            BattleText.text = MonsterHealth.ToString("0");
                            yield return new WaitForSeconds(waitTime);
                        }
                        else if (i % 2 == 1)
                        {
                            float tDamage = MonsterDamage - inventory.itemArmor;
                            if (tDamage <= 0)
                            {
                                tDamage = -tDamage;
                                _barManager.HealthDecrease(tDamage);
                                _barManager.EnergyDecrease(RequiredEnergyForKilling);
                                BattleText.text = tDamage.ToString("0") + " Damage aldın!";
                            }
                            else
                            {
                                _barManager.HealthDecrease(tDamage);
                                _barManager.EnergyDecrease(RequiredEnergyForKilling);
                                BattleText.text = tDamage.ToString("0") + " Damage aldın!";
                            }
                            yield return new WaitForSeconds(waitTime);
                        }
                    }
                    else if(MonsterHealth <= 0)
                    {
                        //Düşman öldüyse
                        BattleText.text = "YOU WİN!!";
                        _barManager.GiveMeTheMoney(Reward);
                        _barManager.GetExperience(Experience);
                        yield return new WaitForSeconds(waitTime);
                        BattleText.text = "";
                        break;
                    }
                    else if(_barManager.healthBar.GetComponent<Image>().fillAmount == 0)
                    {
                        //Sen öldüysen
                        BattleText.text = "YOU LOSE!!";
                        yield return new WaitForSeconds(waitTime);
                        BattleText.text = "";
                        break;
                    }
                }
            }
            else
            {
                BattleText.text = "You Need Both Weapon And Armor!!!";
                yield return new WaitForSeconds(waitTime);
                BattleText.text = "";
                break;
            }
            yield return null;
        }
    }
}
