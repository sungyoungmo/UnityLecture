using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSliderTest : MonoBehaviour
{
    public float HP;

    private Slider slider;

    


    private void Awake()
    {
        slider = GetComponent<Slider>();
    }


    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = HP;
        slider.value = HP;
    }

    public void OnDamagerButtonClick(float damage)
    {
        HP -= damage;
        slider.value = HP;
    }
}
