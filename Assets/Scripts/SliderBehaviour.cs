using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] Slider sliderPrefab;

    public void SetHealth(float health,float maxHealth)
    {
        sliderPrefab.value = health;
        sliderPrefab.maxValue = maxHealth;
    }
}
