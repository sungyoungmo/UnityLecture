using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance { get; private set; }

    public Transform lightTransform; // Directional Light 오브젝트 참조

    private bool isDay = true; // 낮이면 True, 밤이면 false

    // observer Patten을 부분적으로 구현
    public System.Action<bool> onDayComesUp;
    // 유니티에서 옵저버 패턴 구현시 delegate 또는 eventHandler를 주로 활용

    private void Awake()
    {
        Instance = this;

        onDayComesUp = (isDay) => { lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0); };
    }


    public void DayToggleButtonClick() // 낮밤 토글. 버튼이 호출
    {
        isDay = !isDay; // isDay 토글

        onDayComesUp?.Invoke(isDay);

        

    }


}
