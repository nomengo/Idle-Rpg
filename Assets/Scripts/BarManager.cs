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

    public int Level = 1;
    public int Money = 0;

    private void Start()
    {
        StartCoroutine(UpdateTheBars());
    }

    public void GetExperience(float experience)
    {
        experienceBar.GetComponent<Image>().fillAmount += experience / Level;
    }

    public void HealthDecrease(float damage)
    {
        healthBar.GetComponent<Image>().fillAmount -= damage / Level;
        //Debug.Log(healthBar.GetComponent<Image>().fillAmount);
    }

    public void EnergyDecrease(float amount)
    {
        energyBar.GetComponent<Image>().fillAmount -= amount / Level;
    }

    public void GiveMeTheMoney(int money)
    {
        Money += money;
        moneyText.text = Money.ToString();
    }

    public void TakeMyMoney(int money)
    {
        Money -= money;
        moneyText.text = Money.ToString();
    } 

    private void Update()
    {
        if (experienceBar.GetComponent<Image>().fillAmount == 1)
        {
            //PlayerData.level += level;
            Level += 1;
            experienceText.text = "LEVEL: " + Level.ToString("0"); //PlayerData.level.ToString("0");
            experienceBar.GetComponent<Image>().fillAmount = 0;
        }
    }

    public IEnumerator UpdateTheBars()
    {
        while (true)
        {
            if (energyBar.GetComponent<Image>().fillAmount < 1)
            {
                energyBar.GetComponent<Image>().fillAmount += 0.1f;
                yield return new WaitForSeconds(waitingTime);
            }
            if (healthBar.GetComponent<Image>().fillAmount < 1)
            {
                healthBar.GetComponent<Image>().fillAmount += 0.1f;
                yield return new WaitForSeconds(waitingTime);
            }
            yield return null;
        }
    }

    public void SaveBarManager()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadBarManager()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Level = data.Level;
        Money = data.Money;
    }
}
