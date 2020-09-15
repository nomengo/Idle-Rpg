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
    private QuestGoal questGoal;
    private PanelTransitions panelTransitions;

    private bool isTheBattleCompleted;

    private int Reward;
    private int receivedCreatureID;

    private void Start()
    {
        waitTime = 1f;//Remember to always check waitTime for if it's 0 or not 
        questGoal = FindObjectOfType<QuestGoal>();
        _barManager = FindObjectOfType<BarManager>();
        inventory = FindObjectOfType<Inventory>();
        panelTransitions = FindObjectOfType<PanelTransitions>();
    }

    public void ReceiveId(int id)
    {
        foreach (var creature in creatureDataList.creatureList)
        {
            if(creature.CreatureID == id)
            {

                receivedCreatureID = id;
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
       StartCoroutine(BattleCo());
    }

    private float CalculateTheDamages(float armor , float damage)
    {
        if(armor > damage)
        {
            return 0;
            //Do nothing... maybe later
        }
        else if(armor==damage)
        {
            return 0;
            //Do nothing... maybe later
        }
        else
        {
            damage -= armor;
            return damage;
        }
    }

    public IEnumerator BattleCo()
    {
        while (true)
        {
            if (!isTheBattleCompleted)
            {
                if (inventory.itemDamage > 0 && inventory.itemArmor > 0)
                {
                    for (int i = 1; i < 9; i++)
                    {
                        if (MonsterHealth > 0 && _barManager.healthBar.GetComponent<Image>().fillAmount > 0)
                        {
                            //Both sides are healthy
                            if (i % 2 == 0)
                            {
                                float gDamage = CalculateTheDamages(MonsterArmor, inventory.itemDamage);
                                MonsterHealth -= gDamage;
                                //Debug.Log(MonsterHealth);
                                BattleText.text = MonsterHealth.ToString("0");
                                yield return new WaitForSeconds(waitTime);
                            }
                            else if (i % 2 == 1)
                            {
                                float tDamage = CalculateTheDamages(inventory.itemArmor, MonsterDamage);
                                _barManager.HealthDecrease(tDamage);
                                _barManager.EnergyDecrease(RequiredEnergyForKilling);
                                BattleText.text = tDamage.ToString("0") + " Damage aldın!";
                                yield return new WaitForSeconds(waitTime);
                            }
                        }
                        else if (MonsterHealth <= 0)
                        {
                            //if enemy dies
                            BattleText.text = "YOU WİN!!";
                            _barManager.GiveMeTheMoney(Reward);
                            _barManager.GetExperience(Experience);
                            //Take and send creature's id to QuestGoal for confirmation
                            questGoal.QuestProgress(receivedCreatureID);
                            yield return new WaitForSeconds(waitTime);
                            BattleText.text = "";
                            isTheBattleCompleted = true;
                            break;
                        }
                        else if (_barManager.healthBar.GetComponent<Image>().fillAmount == 0)
                        {
                            //if you die
                            BattleText.text = "YOU LOSE!!";
                            yield return new WaitForSeconds(waitTime);
                            BattleText.text = "";
                            isTheBattleCompleted = true;
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
            }
            else
            {
                isTheBattleCompleted = false;
                panelTransitions.GoToHuntingPanel();
                break;
            }
            yield return null;
        }
    }
}
