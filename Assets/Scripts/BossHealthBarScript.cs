using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    

    // Start is called before the first frame update
    public void SetHealth(int healthValue)
    {
        slider.value = healthValue;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int healthValue)
    {
        slider.maxValue = healthValue;
        slider.value = healthValue;

        fill.color = gradient.Evaluate(1f);

    }
}
