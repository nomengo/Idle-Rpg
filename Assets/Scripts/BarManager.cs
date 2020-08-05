using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image experienceBar;
    public Image healthBar;
    public Image energyBar;
    public Text experienceText;

    private int level = 0;

    public void GetExperience(float experience)
    {
        experienceBar.GetComponent<Image>().fillAmount += experience;
    }

    public void HealthDecrease(float damage)
    {
        healthBar.GetComponent<Image>().fillAmount -= damage;
    }

    public void EnergyDecrease(float amount)
    {
        energyBar.GetComponent<Image>().fillAmount -= amount;
    }

    private void Update()
    {
        if (experienceBar.GetComponent<Image>().fillAmount == 1)
        {
            level++;
            experienceText.text = "LEVEL: " + level.ToString("0");
            experienceBar.GetComponent<Image>().fillAmount = 0;
        }
    }

}
