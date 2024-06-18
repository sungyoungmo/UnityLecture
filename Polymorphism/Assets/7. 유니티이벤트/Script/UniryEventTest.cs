using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class UniryEventTest : MonoBehaviour
{

    private float maxHp = 100;
    private float currentHP = 100;
    private float HpCache= 100;

    public UnityEvent someEvent;

    public UnityEvent<float> onHPChange;
    public UnityEvent<string> onHPChangeString;

    // 유니티 이벤트(UnityEvent)
    // 유니티 Inspector 에서 델리게이트와 같이 특정 함수를 등록하여 호출할 수 있도록 만들어진 클래스

    private void Start()
    {
        someEvent?.Invoke();

        onHPChange.AddListener(PrintCurrentHP);
    }

    public void PrintCurrentHP(float value)
    {
        print($"current HP Amount is : {value}");
    }
    public void SomeMethod()
    {
        print("Some Event Called.");
    }

    public void OnValueChange(float value)
    {
        print(value);
    }

    public void OnPositionChange(Vector2 value)
    {
        transform.position = value;
    }

    public void OnDamageButtonClick()
    {
        currentHP -= 10;
    }


    private void Update()
    {
        if (HpCache != currentHP)
        {
            // hp 값이 바뀌었다면
            onHPChange?.Invoke(currentHP/maxHp);
            onHPChangeString?.Invoke((currentHP/maxHp).ToString("p1"));
            HpCache = currentHP;
        }
    }

}
