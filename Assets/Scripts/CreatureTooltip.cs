using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreatureTooltip : MonoBehaviour
{
    private static CreatureTooltip instance;

    [SerializeField] private Text HealthText;
    [SerializeField] private Text DamageText;
    [SerializeField] private Text EnergyText;
    [SerializeField] private Text ArmorText;

    //[SerializeField] private RectTransform BackgroundRect;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ShowTooltip(10, 255, 80, 10.9f);
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(float healthText , float damageText , float energyText , float armorText)
    {
        gameObject.SetActive(true);

        HealthText.text = "Health: " + healthText.ToString();
        DamageText.text = "Damage: " + damageText.ToString();
        EnergyText.text = "Energy: " + energyText.ToString();
        ArmorText.text =  "Armor: " + armorText.ToString();

        //Vector2 backgroundSize = new Vector2(HealthText.preferredWidth , HealthText.preferredHeight);
        //BackgroundRect.sizeDelta = backgroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(float healthText, float damageText, float energyText, float armorText)
    {
        instance.ShowTooltip(healthText, damageText, energyText, armorText);
    }

    public static void HideTooltip_Static()
    {
        instance.HideTooltip();
    }

}
