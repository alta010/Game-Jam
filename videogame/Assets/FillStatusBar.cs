using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enable = false;
        }

        if (slider.value > slider.minvalue && !fillImage.enabled)
        {
            fillImage.enable = true;
        }

        float fillValue = playerHealth.currentHealth / playerhealth.maxHealth;
        if (fillValue <= slider.maxvalue)
        {
            fillImage.color = Color.white;
        }

        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }

        slider.value = fillValue;
    }
}
