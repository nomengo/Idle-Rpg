using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("healthBar").GetComponent<Image>();

        barImage.fillAmount = 0.6f;
    }
}
