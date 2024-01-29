using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float fillSpeed = 0.5f;
    public bool Click = false;
    public CanvasGroup healthBarCanvasGroup;

    public delegate void OnHealthFull();
    public event OnHealthFull HealthFull;


    public void Start()
    {
        //healthBarCanvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Click == true)
        {
            if (slider.value < slider.maxValue)
            {
                slider.value += fillSpeed * Time.deltaTime;
            }
            else
            {
                OnHealthFullHandler();
            }
        }
        else
        {
            slider.value = 0;
        }
    }

    private void OnHealthFullHandler()
    {
        HealthFull?.Invoke();
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
