using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public GameObject experienceBar;
    public GameObject healthBar;
    public GameObject energyBar;
    public Text moneyText;
    public Text experienceText;

    private int level = 1;

    public void GetExperience(float experience)
    {
        experienceBar.GetComponent<Image>().fillAmount += experience / level;
    }

    public void HealthDecrease(float damage)
    {
        healthBar.GetComponent<Image>().fillAmount -= damage;
    }

    public void EnergyDecrease(float amount)
    {
        energyBar.GetComponent<Image>().fillAmount -= amount;
    }

    public void GiveMeTheMoney(int money)
    {
        PlayerData.money += money;
        moneyText.text = PlayerData.money.ToString();
    }

    private void Update()
    {
        if (experienceBar.GetComponent<Image>().fillAmount == 1)
        {
            level++;
            experienceText.text = "LEVEL: " + level.ToString("0");
            experienceBar.GetComponent<Image>().fillAmount = 0;
        }
        if(energyBar.GetComponent<Image>().fillAmount <= 0)
        {
            energyBar.GetComponent<Image>().fillAmount = 1;
        }
        if(healthBar.GetComponent<Image>().fillAmount <= 0)
        {
            healthBar.GetComponent<Image>().fillAmount = 1;
        }
    }

}
