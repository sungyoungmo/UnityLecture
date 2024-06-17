using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance { get; private set; }

    public Transform lightTransform; // Directional Light ������Ʈ ����

    private bool isDay = true; // ���̸� True, ���̸� false

    // observer Patten�� �κ������� ����
    public System.Action<bool> onDayComesUp;
    // ����Ƽ���� ������ ���� ������ delegate �Ǵ� eventHandler�� �ַ� Ȱ��

    private void Awake()
    {
        Instance = this;

        onDayComesUp = (isDay) => { lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0); };
    }


    public void DayToggleButtonClick() // ���� ���. ��ư�� ȣ��
    {
        isDay = !isDay; // isDay ���

        onDayComesUp?.Invoke(isDay);

        

    }


}
