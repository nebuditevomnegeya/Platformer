using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthController : MonoBehaviour
{
    private Slider healthBar;
    void Awake()
    {
        healthBar = GameObject.Find("HPSlider").GetComponent<Slider>();
    }

    public void SetUpHealthBar(int startValue)
    {
        healthBar.maxValue = startValue;
        healthBar.value = startValue;
    }
    public void UpdateHealthBar(int value)
    {
        healthBar.value = value;
    }

    void Update()
    {
        
    }
}
