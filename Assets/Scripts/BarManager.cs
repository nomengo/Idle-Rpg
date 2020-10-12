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

    public float waitingTime = 0.1f; 

    private int level = 1;

    private void Start()
    {
        StartCoroutine(UpdateTheBars());
    }

    public void GetExperience(float experience)
    {
        experienceBar.GetComponent<Image>().fillAmount += experience / level;
    }

    public void HealthDecrease(float damage)
    {
        healthBar.GetComponent<Image>().fillAmount -= damage / level;
        Debug.Log(healthBar.GetComponent<Image>().fillAmount);
    }

    public void EnergyDecrease(float amount)
    {
        energyBar.GetComponent<Image>().fillAmount -= amount / level;
    }

    public void GiveMeTheMoney(int money)
    {
        PlayerData.money += money;
        moneyText.text = PlayerData.money.ToString();
    }

    public void TakeMyMoney(int money)
    {
        PlayerData.money -= money;
        moneyText.text = PlayerData.money.ToString();
    } 

    private void Update()
    {
        if (experienceBar.GetComponent<Image>().fillAmount == 1)
        {
            //PlayerData.level += level;
            level += 1;
            experienceText.text = "LEVEL: " + level.ToString("0"); //PlayerData.level.ToString("0");
            experienceBar.GetComponent<Image>().fillAmount = 0;
        }
    }

    public IEnumerator UpdateTheBars()
    {
        while (true)
        {
            if (energyBar.GetComponent<Image>().fillAmount < 1)
            {
                yield return new WaitForSeconds(waitingTime);
                energyBar.GetComponent<Image>().fillAmount += 0.1f;
            }
            if (healthBar.GetComponent<Image>().fillAmount < 1)
            {
                yield return new WaitForSeconds(waitingTime);
                healthBar.GetComponent<Image>().fillAmount += 0.1f;
            }
            yield return null;
        }
    }
}
