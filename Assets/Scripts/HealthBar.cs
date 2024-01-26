using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float fillSpeed = 0.5f;
    public bool Click = false;

    private void Update()
    {
        if (Click == true)
        {
            if (slider.value < slider.maxValue)
            {
                slider.value += fillSpeed * Time.deltaTime;
            }
        }
        else
        {
            slider.value = 0;
        }
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = 0;
    }
    public bool IsFull()
    {
        return slider.value >= slider.maxValue;
    }
}
